using MovieList.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.MovieOperations.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly MovieListDbContext _dbContext;
        public GetMoviesQuery(MovieListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<MoviesViewModel> Handle()
        {
            var movieList = _dbContext.Movies.OrderBy(x => x.Id).ToList<Movie>();
            List<MoviesViewModel> vm = new List<MoviesViewModel>();
            foreach (var movie in movieList)
            {
                vm.Add(new MoviesViewModel()
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Director = movie.Director,
                    Genre = movie.Genre,
                    Language = movie.Language,
                    Ratings=movie.Ratings,
                    Released = movie.Released.Date.ToString("dd/MM/yyyy")
                });
            }
            return vm;
        }
    }

    public class MoviesViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public double Ratings { get; set; }
        public string Released { get; set; }
    }
}
