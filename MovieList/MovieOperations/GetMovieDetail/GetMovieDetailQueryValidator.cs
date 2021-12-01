using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.MovieOperations.GetMovieDetail
{
    public class GetMovieDetailQueryValidator:AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(query => query.MovieId).NotEmpty();
        }
    }
}
