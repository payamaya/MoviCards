using AutoMapper;
using MovieCardsAPI.Models.DTOs;
using MovieCardsAPI.Models.DTOs.MovieCardsAPI.Models.DTOs;
using MovieCardsAPI.Models.Entities;

namespace MovieCardsAPI.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Mapping from Movie to various DTOs
            CreateMap<Movie, MovieCreateDTO>().ReverseMap();
            /*    CreateMap<Movie, MovieUpdateDTO>().ReverseMap();*/
            CreateMap<MovieUpdateDTO, Movie>()
            .ForMember(dest => dest.MovieActors, opt => opt.Ignore())
            .ForMember(dest => dest.MovieGenres, opt => opt.Ignore());

            // Mapping for simple MovieDTO
            CreateMap<Movie, MovieDTO>()
                .ConstructUsing(src => new MovieDTO(src.Id, src.Title, src.Rating, src.ReleaseDate, src.Description));

            // Mapping for detailed MovieDetailsDTO
            CreateMap<Movie, MovieDetailsDTO>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.Name))
                .ForMember(dest => dest.ActorNames, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor.Name)))
                .ForMember(dest => dest.GenreNames, opt => opt.MapFrom(src => src.MovieGenres.Select(mg => mg.Genre.Name)))
                .ForMember(dest => dest.DirectorContactEmail, opt => opt.MapFrom(src => src.Director.ContactInformation.Email))
                .ForMember(dest => dest.DirectorContactPhone, opt => opt.MapFrom(src => src.Director.ContactInformation.PhoneNumber));
        }
    }

}

