using System.Runtime.CompilerServices;

namespace movieProject.Models.Weather
{
    public class WeatherModel 
    {
        public string Forecast { get; set; }
        public string Main { get; set; }
        public double CurrentTemp { get; set; }
        public double DailyLow { get; set; }
        public double DailyHigh { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
