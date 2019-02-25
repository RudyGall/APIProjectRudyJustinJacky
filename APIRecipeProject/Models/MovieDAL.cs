using Newtonsoft.Json.Linq;
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
        public static MovieFavorite GetMovie(int i)
        {
            string output = GetData("http://www.omdbapi.com/?i=tt3896198&apikey=61912d7d");
            MovieFavorite movie = new MovieFavorite(output, i);

            return movie;
        }
        public static List<MovieFavorite> GetMovies()
        {
            List<MovieFavorite> movies = new List<MovieFavorite>();
            string output = GetData("http://www.omdbapi.com/?i=tt3896198&apikey=61912d7d");


            JObject movieJson = JObject.Parse(output);

            List<JToken> movieTokens = movieJson["Title"]["Year"]["Rated"]["Genre"]["Metascore"]["imdbRating"]["BoxOffice"].ToList();

            for (int i = 0; i < movieTokens.Count; i++)
            {
                MovieFavorite movie = new MovieFavorite();

                movie.Title = movieTokens[i]["Title"].ToString();
                movie.Year = movieTokens[i]["Year"].ToString(Year);
                movie.Rated = movieTokens[i]["Rated"].ToString();
                movie.Genre = movieTokens[i]["Genre"].ToString();
                movie.Metascore = movieTokens[i]["Metascore"].ToString();
                movie.imdbRating = movieTokens[i]["imdbRating"].ToString();
                movie.BoxOffice = movieTokens[i]["BoxOffice"].ToString();

                movies.Add(movie);
            }

            return movies;
        }
    }
}