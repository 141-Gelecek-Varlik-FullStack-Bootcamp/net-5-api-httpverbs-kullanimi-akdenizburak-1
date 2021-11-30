using AutoMapper;
using MovieList.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.MovieOperations.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
        private readonly MovieListDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieCommand(MovieListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Title.ToLower() == Model.Title.ToLower());

            if (movie is not null)
                throw new InvalidOperationException("Film zaten mevcut");
            movie = _mapper.Map<Movie>(Model);  //new Movie();
            //movie.Title = Model.Title;
            //movie.Language = Model.Language;
            //movie.Genre = Model.Genre;
            //movie.Director = Model.Director;
            //movie.Ratings = Model.Ratings;
            //movie.Year = Model.Year;
            //movie.Released = Model.Released;

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
        public class CreateMovieModel
        {
            public string Title { get; set; }
            public int Year { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public string Language { get; set; }
            public double Ratings { get; set; }
            public DateTime Released { get; set; }
        }
    }
}
