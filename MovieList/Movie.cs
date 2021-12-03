using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Title { get; set; }

        [Range(1850,2021, ErrorMessage = "Yıl {1}-{2} aralığı dışında olamaz!")]
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
