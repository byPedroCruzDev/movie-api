using Microsoft.AspNetCore.Mvc;
using movie_api.Models;

namespace movie_api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movie = new List<Movie>();
    private static int id = 0;

    [HttpPost]
    public IActionResult CreateMovie([FromBody] Movie movies)
    {
        movies.Id = id++;
        movie.Add(movies);
        return CreateAtAction(nameof(GetMoviesWithId), 
                            new (id == movies.Id), movie)
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 20 )
    {
        return movie.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IsActionResult GetMovieWithId(int id)
    {
      var movies = movie.FirstOrDefault(movie => movie.Id == id);
      if(movies == null) return NotFound();
      return Ok(); 

        
    }
}
