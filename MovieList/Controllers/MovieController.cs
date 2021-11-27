using Microsoft.AspNetCore.Mvc;
using MovieList.DBOperations;
using MovieList.MovieOperations.CreateMovie;
using MovieList.MovieOperations.GetMovies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MovieList.MovieOperations.CreateMovie.CreateMovieCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieListDbContext _context;

        public MovieController (MovieListDbContext context)
        {
            _context=context;
        }

        //Tüm filmleri getiren GET metodu
        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        //id ye göre film getiren FromRoute kullanımlı GET metodu
        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public Movie GetById(int id)
        {
            var movie = _context.Movies.Where(movie => movie.Id == id).SingleOrDefault();
            return movie;
        }

        //Yeni bir film eklemek için post metodu
        // POST api/<MovieController>
        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context);
            try
            {
                command.Model = newMovie;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        //Filmleri güncelleyen PUT metodu
        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

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

            _context.SaveChanges();
            return Ok();
        }

        //filmleri id'ye göre silen DELETE metodu
        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Single(x => x.Id == id);
            if (movie is null)
            {
                return BadRequest();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
