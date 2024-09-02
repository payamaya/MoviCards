
namespace Movies.Shared.DTOs
{
    public record MovieUpdateDTO : MovieManipulationDTO
    {
        public Guid Id { get; init; }

    }
}


