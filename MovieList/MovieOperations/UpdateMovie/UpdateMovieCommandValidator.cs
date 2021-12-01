using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommandValidator:AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);
            RuleFor(command => command.Model.Language).NotEmpty();
            RuleFor(command => command.Model.Ratings).GreaterThan(0);
            RuleFor(command => command.Model.Released).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty();
        }
    }
}
