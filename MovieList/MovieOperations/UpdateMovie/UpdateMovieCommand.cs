using MovieList.DBOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
