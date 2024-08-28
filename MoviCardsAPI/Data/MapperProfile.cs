using AutoMapper;
using MovieCardsAPI.Models.DTOs;
using MovieCardsAPI.Models.Entities;

namespace MovieCardsAPI.Data
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Movie, MovieCreateDTO>().ReverseMap();

            CreateMap<Movie,MovieUpdateDTO>().ReverseMap();

            CreateMap<Movie, MovieDTO>().
                ConstructUsing(src => new MovieDTO(src.Id, src.Title, src.Rating, src.ReleaseDate, src.Description));

            CreateMap<Movie, MovieDetailsDTO>().ReverseMap();
        }
    }
}
