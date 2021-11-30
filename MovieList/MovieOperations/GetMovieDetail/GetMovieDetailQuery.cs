using AutoMapper;
using MovieList.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.MovieOperations.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly MovieListDbContext _dbContext;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }
        public GetMovieDetailQuery(MovieListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public MovieDetailViewModel Handle()
        {
            var movie = _dbContext.Movies.Where(movie => movie.Id == MovieId).SingleOrDefault();
            if (movie is null)
                throw new InvalidOperationException("Film Bulunamadı");

            MovieDetailViewModel vm = _mapper.Map< MovieDetailViewModel > (movie);  //new MovieDetailViewModel();
            //vm.Title = movie.Title;
            //vm.Year = movie.Year;
            //vm.Released = movie.Released.Date.ToString("dd/MM/yyyy");
            //vm.Genre = movie.Genre;
            //vm.Language = movie.Language;
            //vm.Ratings = movie.Ratings;
            return vm;
        }
    }

    public class MovieDetailViewModel
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
