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
    public void AddMovie([FromBody] Movie movies)
    {
        movies.Id = id++;
        movie.Add(movies);
        Console.WriteLine(movies.Id);

        Console.WriteLine(movies.Min);
        Console.WriteLine(movies.Title);
        Console.WriteLine(movies.Description);
        Console.WriteLine(movies.Gender);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
        return movie;
    }

    [HttpGet("{id}")]
    public Movie? GetMoviesWithId(int id)
    {
       return movie.FirstOrDefault(movie => movie.Id == id);

        
    }
}
