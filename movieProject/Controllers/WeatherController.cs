using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movieProject.Models.Movie;
using movieProject.Models.Weather;

namespace movieProject.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepository repo;
        public WeatherController(IWeatherRepository repo)
        {
            this.repo = repo;
        }
        // GET: WeatherController

        public ActionResult Index()
        {
            var coordinates = repo.GetCoordinates("boston");
            var weather = repo.GetWeather(coordinates);
            return View(weather);
        }

        [HttpPost]
        public ActionResult Index(string queryString)
        {
            if (!string.IsNullOrEmpty(queryString))
            {
                try
                {
                    var coordinates = repo.GetCoordinates(queryString);
                    var weather = repo.GetWeather(coordinates);
                    return View(weather);
                }
                catch (ArgumentOutOfRangeException)
                {
                    var weather = new WeatherModel()
                    {
                        Forecast = "an error occured",
                        Main = "an error occured"
                    };
                    return View(weather);
                }

            }
            else
            {
                var weather = new WeatherModel()
                {
                    Forecast = "an error occured",
                    Main = "an error occured"
                };
                return View(weather);
            }
        }
    }
}
