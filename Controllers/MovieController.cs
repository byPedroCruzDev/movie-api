using Microsoft.AspNetCore.Mvc;
using movie_api.Models;

namespace movie_api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movie = new List<Movie>();

    public void AddMovie([FromBody] Movie movies)
    {
        movie.Add(movies);

        Console.WriteLine(movies.Min);
        Console.WriteLine(movies.Title); 
        Console.WriteLine(movies.Description);
        Console.WriteLine(movies.Gender);
    }

}
