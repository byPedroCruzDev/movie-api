using System.ComponentModel.DataAnnotations;

namespace movie_api.Data.Dto
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(1)]
        public string Title { get; set; }


        [Required(ErrorMessage = "Description is required")]
        [StringLength(600, ErrorMessage = "Minimal descriptio is 15 characters")]
        public string Description { get; set; }


        [Required]
        [StringLength(60, ErrorMessage = "Exceed the number of characters")]
        public string Gender { get; set; }


        [Required]
        [Range(70, 600, ErrorMessage = "Minimal Min 70, Max min 600")]
        public int Min { get; set; }
    }
}
