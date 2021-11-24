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
        // GET: api/<MovieController>
        [HttpGet]
        public List<Movie> GetMovies()
        {
            var movieList = MovieList.OrderBy(x => x.Id).ToList<Movie>();
            return movieList;
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public Movie GetById(int id)
        {
            var movie = MovieList.Where(movie => movie.Id == id).SingleOrDefault();
            return movie;
        }

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

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
