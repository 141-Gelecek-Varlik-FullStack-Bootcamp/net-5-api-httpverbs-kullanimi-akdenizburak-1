using MovieList.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly MovieListDbContext _context;
        public int MovieId { get; set; }
        public UpdateMovieModel Model { get; set; }
        public UpdateMovieCommand(MovieListDbContext context)
        {
            _context=context;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("Güncellenecek Film Bulunamadı");
            movie.Genre = Model.Genre != default ? Model.Genre : movie.Genre;
            movie.Year = Model.Year != default ? Model.Year : movie.Year;
            movie.Ratings = Model.Ratings != default ? Model.Ratings : movie.Ratings;
            movie.Title = Model.Title != default ? Model.Title : movie.Title;
            movie.Director = Model.Director != default ? Model.Director : movie.Director;
            _context.SaveChanges();
        }
        public class UpdateMovieModel
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
