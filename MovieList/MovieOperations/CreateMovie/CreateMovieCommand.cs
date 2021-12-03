using AutoMapper;
using MovieList.DBOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            movie = _mapper.Map<Movie>(Model);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
        public class CreateMovieModel
        {

            [Required(ErrorMessage = "{0} alanı gereklidir.")]
            public string Title { get; set; }

            [Range(1850, 2021, ErrorMessage = "Yıl {1}-{2} aralığı dışında olamaz!")]
            public int Year { get; set; }

            [Required(ErrorMessage = "{0} alanı gereklidir.")]
            [StringLength(30, ErrorMessage = "En fazla {1} karakter uzunluğunda olmalıdır.")]
            public string Genre { get; set; }

            [Required(ErrorMessage = "{0} alanı gereklidir.")]
            public string Director { get; set; }

            [Required(ErrorMessage = "{0} alanı gereklidir.")]
            public string Language { get; set; }

            [Required(ErrorMessage = "{0} alanı gereklidir.")]
            [Range(0, 10, ErrorMessage = "Puan 0-10 aralığı dışında olamaz!")]
            public double Ratings { get; set; }

            [Required(ErrorMessage = "{0} alanı gereklidir.")]
            [DataType(DataType.DateTime)]
            public DateTime Released { get; set; }
        }
    }
}
