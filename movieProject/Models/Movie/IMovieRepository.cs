using Newtonsoft.Json.Linq;

namespace movieProject.Models.Movie
{
    public interface IMovieRepository
    {
        public IEnumerable<MovieModel> GetBySearchName(string query);
        public IEnumerable<MovieModel> GetByTopOfWeek();
    }
}
