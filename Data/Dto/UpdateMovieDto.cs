using System.ComponentModel.DataAnnotations;

namespace movie_api.Data.Dto
{
    public class UpdateMovieDto
    
    {
        
        [MinLength(1)]
        public string Title { get; set; }


        [StringLength(600, ErrorMessage = "Minimal descriptio is 15 characters")]
        public string Description { get; set; }


        [StringLength(60, ErrorMessage = "Exceed the number of characters")]
        public string Gender { get; set; }

        
        [Range(70, 600, ErrorMessage = "Minimal Min 70, Max min 600")]
        public int Min { get; set; }
    }
}