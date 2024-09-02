

namespace MovieCardsAPI.Data
{
    public class MapperProfile : Profile
    {
     /* 
      In the constructor we create our mapping*
     */
        public MapperProfile()
        {
            // Mapping from Movie to various DTOs
            CreateMap<Movie, MovieCreateDTO>().ReverseMap();
  
       
            CreateMap<MovieUpdateDTO, Movie>()
            .ForMember(dest => dest.MovieActors, opt => opt.Ignore())
            .ForMember(dest => dest.MovieGenres, opt => opt.Ignore());

            // Mapping for simple MovieDTO
            CreateMap<Movie, MovieDTO>()
               /* .ForMember(dest => dest.Title, opt => opt
                .MapFrom(src => $"{src.Title}{(string.IsNullOrEmpty(src.Description) ? string.Empty : ", ")}{src.Description}"))*/
                ;

            // Mapping for detailed MovieDetailsDTO
            CreateMap<Movie, MovieDetailsDTO>().ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.Name))
                .ForMember(dest => dest.DirectorContactEmail, opt => opt.MapFrom(src => src.Director.ContactInformation.Email))
                .ForMember(dest => dest.DirectorContactPhone, opt => opt.MapFrom(src => src.Director.ContactInformation.PhoneNumber))
                .ForMember(dest => dest.ActorNames, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor.Name).ToList()))
                .ForMember(dest => dest.GenreNames, opt => opt.MapFrom(src => src.MovieGenres.Select(mg => mg.Genre.Name).ToList())); ;
        }
    }

}

