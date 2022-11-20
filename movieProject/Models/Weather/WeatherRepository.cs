using Newtonsoft.Json.Linq;
using System.Text;
using System.Web;

namespace movieProject.Models.Weather
{
    public class WeatherRepository : IWeatherRepository
    {
        public double ConvertFromDegreesToDecimals(string degreeMinuteSecond)
        {
            var degree = degreeMinuteSecond.Split('\u00B0')[0];
            var minutes = degreeMinuteSecond.Split('\u00B0')[1].Split('\u0027')[0];
            var seconds = degreeMinuteSecond.Split('\u00B0')[1].Split('\u0027')[1].Split('\u0027')[0];

            if (degreeMinuteSecond.Contains("S") || degreeMinuteSecond.Contains("W"))
            {
                return -1 * Math.Round(Convert.ToDouble(degree) + (Convert.ToDouble(minutes) / 60) + (Convert.ToDouble(seconds) / 3600), 2);
            }
            else return Math.Round(Convert.ToDouble(degree) + (Convert.ToDouble(minutes) / 60) + (Convert.ToDouble(seconds) / 3600), 2);
        }

        public LatAndLong GetCoordinates(string query)
        {
            var encode = new ASCIIEncoding();
            var queryEncode = HttpUtility.UrlEncode(query, encode);

            var geoCodingURL = $"https://api.opencagedata.com/geocode/v1/json?q={queryEncode}&key=37dabb7720664efc89890503a7de624d";
            var geoCodingResult = Application.ApiTask(geoCodingURL);
            var geoCodingResponse = Application.ApiResponse(geoCodingResult);
            return new LatAndLong()
            {
                Latitude = ConvertFromDegreesToDecimals(geoCodingResponse["results"][0]["annotations"]["DMS"]["lat"].ToString()),
                Longitude = ConvertFromDegreesToDecimals(geoCodingResponse["results"][0]["annotations"]["DMS"]["lng"].ToString())
            };
        }

        public WeatherModel GetWeather(LatAndLong coordinates)
        {
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?lat={coordinates.Latitude}&lon={coordinates.Longitude}&appid=e4e8aab8fe952374ae59c8f37ab04b29&units=imperial";
            var weatherResult = Application.ApiTask(weatherURL);
            var weatherResponse = Application.ApiResponse(weatherResult);
            return new WeatherModel()
            {
                Forecast = weatherResponse["weather"][0]["description"].ToString(),
                Main = weatherResponse["weather"][0]["main"].ToString(),
                CurrentTemp = Convert.ToDouble(weatherResponse["main"]["temp"]),
                DailyLow = Convert.ToDouble(weatherResponse["main"]["temp_min"]),
                DailyHigh = Convert.ToDouble(weatherResponse["main"]["temp_max"]),
                Country = weatherResponse["sys"]["country"].ToString(),
                City = weatherResponse["name"].ToString()
            };
        }
    }
}
