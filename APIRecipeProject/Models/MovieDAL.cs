using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace APIRecipeProject.Models
{
    public class MovieDAL
    {
        public static string GetData(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            rd.Close();

            return data;
        }
        public static MovieDB GetMovie(int i)
        {
            string output = GetData("https://");
            MovieDB movie = new MovieDB(output, i);

            return movie;
        }
        public static List<MovieDB> GetMovies()
        {
            List<MovieDB> movies = new List<MovieDB>();
            string output = GetData("https");


            JObject movieJson = JObject.Parse(output);

            List<JToken> movieTokens = movieJson["?"]["?"].ToList();

            for (int i = 0; i < movieTokens.Count; i++)
            {
                MovieDB movie = new MovieDB();

                movie.? = movieTokens[i]["?"]["?"].ToString();
                movie.? = movieTokens[i]["?"]["?"].ToString();
                movie.? = "/" + movieTokens[i]["?"]["?"].ToString();
                movies.Add(movie);
            }

            return movies;
        }
    }
}