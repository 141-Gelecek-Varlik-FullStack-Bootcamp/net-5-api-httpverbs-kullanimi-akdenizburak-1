using Microsoft.AspNetCore.Mvc;
using MovieList.DBOperations;
using MovieList.MovieOperations.CreateMovie;
using MovieList.MovieOperations.DeleteMovie;
using MovieList.MovieOperations.GetMovieDetail;
using MovieList.MovieOperations.GetMovies;
using MovieList.MovieOperations.UpdateMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MovieList.MovieOperations.CreateMovie.CreateMovieCommand;
using static MovieList.MovieOperations.UpdateMovie.UpdateMovieCommand;

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
        public IActionResult GetById(int id)
        {
            MovieDetailViewModel result;
            try
            {
                GetMovieDetailQuery query = new GetMovieDetailQuery(_context);
                query.MovieId = id;
                result= query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
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
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel updatedMovie)
        {
            try
            {
                UpdateMovieCommand command = new UpdateMovieCommand(_context);
                command.MovieId = id;
                command.Model = updatedMovie;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        //filmleri id'ye göre silen DELETE metodu
        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                DeleteMovieCommand command = new DeleteMovieCommand(_context);
                command.MovieId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }
    }
}
