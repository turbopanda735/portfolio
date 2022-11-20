using Newtonsoft.Json.Linq;

namespace movieProject.Models.Weather
{
    public interface IWeatherRepository
    {
        public WeatherModel GetWeather(LatAndLong coordinates);
        public LatAndLong GetCoordinates(string query);
        public double ConvertFromDegreesToDecimals(string degreeMinuteSecond);
    }
}
