namespace Movies.Shared.DTOs
{
    /*
     * Immutable by Default: Records are immutable by default, meaning once you create an instance, you cannot change its properties (though this can be overridden).
       Concise Syntax: Records use a concise syntax for declaring properties.
       Value Equality: Records provide value-based equality out of the box, meaning 
       two records with the same data are considered equal.
       With-Expressions: You can create a copy of a record with some properties 
       changed using the with expression.

       Use record for immutability, value-based equality, and when you prefer 
      concise syntax.
    */
    /*    public record MovieDTO(int Id, string Title, int Rating, DateTime ReleaseDate, string Description );*/

    /*
       Use class when you need mutability, more complex behavior, or when you 
       need compatibility with frameworks that expect classes.
     * 
    */
    public record MovieDTO
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public int Rating { get; init; }
        public DateTime ReleaseDate { get; init; }
        public string? Description { get; init; }
    }
}
