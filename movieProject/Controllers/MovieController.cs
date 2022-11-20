using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movieProject.Models.Movie;

namespace movieProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository repo;
        public MovieController(IMovieRepository repo)
        {
            this.repo = repo;
        }


        public ActionResult Index()
        {
            var movies = repo.GetByTopOfWeek();
            return View(movies);
        }

        [HttpPost]
        public ActionResult Index(string queryString)
        {
            if (!string.IsNullOrEmpty(queryString))
            {
                var movies = repo.GetBySearchName(queryString);
                return View(movies);
            }
            else
            {
                var movie = new MovieModel()
                {
                    Title = "an error occured"
                };
                IEnumerable<MovieModel> movies = new List<MovieModel>() { movie };
                return View(movies);
            }
        }
    }
}
