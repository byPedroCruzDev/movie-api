using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 20 )
    {
        return _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetWithId(int id)
    {
        var movies = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movies == null) return NotFound();
        var movieDto = _mapper.Map<ReadMovieDto>(movies);
        return Ok(movieDto);


   }

    [HttpPut("{id}")]

    public IActionResult UpdateMovie( int id, [FromBody] UpdateMovieDto movieDto){

        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id
       );
       if(movie == null) return NotFound();
        _mapper.Map(movieDto, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]

    public IActionResult UpdatePatchMovie( int id, JsonPatchDocument<UpdateMovieDto> patch){

        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id
       );
       if(movie == null) return NotFound();

       var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);
       patch.ApplyTo(movieToUpdate, ModelState);

       if(!TryValidateModel(movieToUpdate)){
        return ValidationProblem(ModelState);
       }
        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id
        );
        if(movie == null) return NotFound();
        _context.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }
}
