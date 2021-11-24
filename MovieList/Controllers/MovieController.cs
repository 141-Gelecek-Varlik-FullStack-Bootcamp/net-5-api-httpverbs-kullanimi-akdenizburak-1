using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        //statik bir liste oluşturduk, statik yapma sebebimiz: program her çalıştırıldığında oluşturulup silinmesi
        private static List<Movie> MovieList = new List<Movie>()
        {
            new Movie
            {
                Id=1,
                Title="I Lost My Body",
                Year=2019,
                Director="Jeremy Clapin",
                Genre="Animation,Drama",
                Language="French",
                Ratings=7.6,
                Released=new DateTime(2019,06,16)
            },
            new Movie
            {
                Id=2,
                Title="Capernaum",
                Year=2018,
                Director="Nadine Labaki",
                Genre="Drama",
                Language="Arabic",
                Ratings=8.4,
                Released=new DateTime(2018,03,27)
            },
            new Movie
            {
                Id=3,
                Title="Oldboy",
                Year=2003,
                Director="Park Chan Wook",
                Genre="Action,Drama",
                Language="Korean",
                Ratings=8.5,
                Released=new DateTime(2018,03,27)
            }
        };

        //Tüm filmleri getiren GET metodu
        // GET: api/<MovieController>
        [HttpGet]
        public List<Movie> GetMovies()
        {
            var movieList = MovieList.OrderBy(x => x.Id).ToList<Movie>();
            return movieList;
        }

        //id ye göre film getiren FromRoute kullanımlı GET metodu
        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public Movie GetById(int id)
        {
            var movie = MovieList.Where(movie => movie.Id == id).SingleOrDefault();
            return movie;
        }

        //Yeni bir film eklemek için post metodu
        // POST api/<MovieController>
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie newMovie)
        {
            var movie = MovieList.SingleOrDefault(x => x.Title.ToLower() == newMovie.Title.ToLower()||x.Id==newMovie.Id);
            if (movie is not null)
            {
                return BadRequest();
            }
            MovieList.Add(newMovie);
            return Ok();
        }

        //Filmleri güncelleyen PUT metodu
        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            var movie = MovieList.SingleOrDefault(x => x.Id == id);

            if (movie is null)
            {
                return BadRequest();
            }
            movie.Genre = updatedMovie.Genre != default ? updatedMovie.Genre : movie.Genre;
            movie.Year = updatedMovie.Year != default ? updatedMovie.Year : movie.Year;
            movie.Language = updatedMovie.Language != default ? updatedMovie.Language : movie.Language;
            movie.Ratings = updatedMovie.Ratings != default ? updatedMovie.Ratings : movie.Ratings;
            movie.Title = updatedMovie.Title != default ? updatedMovie.Title : movie.Title;
            movie.Director = updatedMovie.Director != default ? updatedMovie.Director : movie.Director;
            movie.Released = updatedMovie.Released != default ? updatedMovie.Released : movie.Released;
            return Ok();
        }

        //filmleri id'ye göre silen DELETE metodu
        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = MovieList.Single(x => x.Id == id);
            if (movie is null)
            {
                return BadRequest();
            }
            MovieList.Remove(movie);
            return Ok();
        }
    }
}
