using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movie_api.Data;
using movie_api.Data.Dto;
using movie_api.Models;

namespace movie_api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;
    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateMovie([FromBody] 
                                    CreateMovieDto moviesDto)
    {
        Movie movie = _mapper.Map<Movie>(moviesDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetWithId),
                            new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 20 )
    {
        return _context.Movies.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetWithId(int id)
    {
        var movies = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movies == null) return NotFound();
        return Ok(movies);


    }
}
