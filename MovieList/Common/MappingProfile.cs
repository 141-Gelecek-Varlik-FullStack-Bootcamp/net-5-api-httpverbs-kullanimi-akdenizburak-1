using AutoMapper;
using MovieList.MovieOperations.GetMovieDetail;
using MovieList.MovieOperations.GetMovies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MovieList.MovieOperations.CreateMovie.CreateMovieCommand;

namespace MovieList.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<Movie,MovieDetailViewModel>();
            CreateMap<Movie,MoviesViewModel>();
        }
    }
}
