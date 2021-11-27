using MovieList.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly MovieListDbContext _dbContext;
        public int MovieId { get; set; }
        public DeleteMovieCommand(MovieListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var movie = _dbContext.Movies.Single(x => x.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("Silinecek Film Bulunamadı");
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
    }
}
