using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Web;
using static System.Net.WebRequestMethods;

namespace movieProject.Models.Movie
{
    public class MovieRepository : IMovieRepository
    {
        public IEnumerable<MovieModel> GetBySearchName(string query)
        {
            var encode = new ASCIIEncoding();
            var queryEncode = HttpUtility.UrlEncode(query, encode);
            var url = $"https://api.themoviedb.org/3/search/movie?api_key=f2895599f066f2f7361df63bfc1310f4&language=en-US&query={queryEncode}&include_adult=false";
            var jResult = Application.ApiTask(url);
            var movieResponse = Application.ApiResponse(jResult);
            var jArr = (JArray)movieResponse["results"];

            var movieList = new List<MovieModel>();

            for (int i = 0; i < jArr.Count; i++)
            {
                var jObj = (JObject)jArr[i];
                var movieModel = new MovieModel()
                {
                    Id = Convert.ToInt32(jObj["id"]),
                    Title = jObj["title"].ToString(),
                    Overview = jObj["overview"].ToString(),
                    Released = jObj["release_date"].ToString(),
                    Poster = $"https://www.themoviedb.org/t/p/w300_and_h450_bestv2{jObj["poster_path"]}",
                    Backdrop = $"https://www.themoviedb.org/t/p/w300_and_h450_bestv2{jObj["backdrop_path"]}"
                };
                movieList.Add(movieModel);
            }
            return movieList;
        }
        public IEnumerable<MovieModel> GetByTopOfWeek()
        {
            var url = "https://api.themoviedb.org/3/trending/movie/week?api_key=f2895599f066f2f7361df63bfc1310f4";
            var jResult = Application.ApiTask(url);
            var movieResponse = Application.ApiResponse(jResult);
            var jArr = (JArray)movieResponse["results"];

            var movieList = new List<MovieModel>();

            for (int i = 0; i < jArr.Count; i++)
            {
                var jObj = (JObject)jArr[i];
                var movieModel = new MovieModel()
                {
                    Id = Convert.ToInt32(jObj["id"]),
                    Title = jObj["title"].ToString(),
                    Overview = jObj["overview"].ToString(),
                    Released = jObj["release_date"].ToString(),
                    Poster = $"https://www.themoviedb.org/t/p/w300_and_h450_bestv2{jObj["poster_path"]}",
                    Backdrop = $"https://www.themoviedb.org/t/p/w300_and_h450_bestv2{jObj["backdrop_path"]}"
                };
                movieList.Add(movieModel);
            }
            return movieList;
        }
    }
}
