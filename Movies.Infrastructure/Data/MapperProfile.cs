using AutoMapper;
using Domain.Models.Entities;
using Movies.Shared.DTOs;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // Mapping from Movie to various DTOs
        CreateMap<Movie, MovieCreateDTO>().ReverseMap();

        // Update mapping, ignoring properties not included in the DTO
        CreateMap<MovieUpdateDTO, Movie>()
            .ForMember(dest => dest.MovieActors, opt => opt.Ignore())
            .ForMember(dest => dest.MovieGenres, opt => opt.Ignore());

        // Simple DTO mapping
        CreateMap<Movie, MovieDTO>();

        // Detailed DTO mapping with additional mappings
        CreateMap<Movie, MovieDetailsDTO>()
            .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.Name))
            .ForMember(dest => dest.DirectorContactEmail, opt => opt.MapFrom(src => src.Director.ContactInformation.Email))
            .ForMember(dest => dest.DirectorContactPhone, opt => opt.MapFrom(src => src.Director.ContactInformation.PhoneNumber))
            .ForMember(dest => dest.ActorNames, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor.Name).ToList()))
            .ForMember(dest => dest.GenreNames, opt => opt.MapFrom(src => src.MovieGenres.Select(mg => mg.Genre.Name).ToList()));
    }
}
