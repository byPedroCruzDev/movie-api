

using Microsoft.EntityFrameworkCore;
using movie_api.Models;

namespace movie_api.Data;



public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts): base(opts) 
    { 
    
    }

    public DbSet<Movie> Movies { get; set; }
    
}
