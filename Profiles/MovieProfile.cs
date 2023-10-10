using AutoMapper;
using movie_api.Data.Dto;
using movie_api.Models;

namespace movie_api.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
    }
}
