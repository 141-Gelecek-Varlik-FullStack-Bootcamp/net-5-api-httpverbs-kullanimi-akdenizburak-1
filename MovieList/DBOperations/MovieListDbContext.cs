using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.DBOperations
{
    public class MovieListDbContext:DbContext
    {
        public MovieListDbContext(DbContextOptions<MovieListDbContext> options) : base(options) 
        { }
        public DbSet<Movie> Movies { get; set; }//Entity ismi tekil olur(Movie), referans ise çoğul olur(Movies) standardı budur

    }
}
