using System.ComponentModel.DataAnnotations;

namespace movie_api.Data.Dto
{
    public class ReadMovieDto
    {
        public string Title { get; set; }


        public string Description { get; set; }
        public string Gender { get; set; }
        public int Min { get; set; }

        public DateTime ConsultTime {get; set;} = DateTime.Now;
    }
}
