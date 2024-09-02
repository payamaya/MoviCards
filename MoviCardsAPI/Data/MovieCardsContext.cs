public class MovieCardsContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<ContactInformation> ContactInformations { get; set; }

    public MovieCardsContext(DbContextOptions<MovieCardsContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure many-to-many relationships
        modelBuilder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });
        modelBuilder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId });

        // Configure relationships
        modelBuilder.Entity<MovieActor>()
            .HasOne(ma => ma.Movie)
            .WithMany(m => m.MovieActors)
            .HasForeignKey(ma => ma.MovieId);

        modelBuilder.Entity<MovieActor>()
            .HasOne(ma => ma.Actor)
            .WithMany(a => a.MovieActors)
            .HasForeignKey(ma => ma.ActorId);

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(mg => mg.MovieId);

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);

        // Configure one-to-one relationship between Director and ContactInformation
        modelBuilder.Entity<Director>()
            .HasOne(d => d.ContactInformation)
            .WithOne(ci => ci.Director)
            .HasForeignKey<ContactInformation>(ci => ci.DirectorId);

        // Seed data
        var directorId = Guid.NewGuid();
        modelBuilder.Entity<Director>().HasData(
            new Director { Id = directorId, Name = "Director One", DateOfBirth = new DateTime(1970, 1, 1) }
        );

        var actorId = Guid.NewGuid();
        modelBuilder.Entity<Actor>().HasData(
            new Actor { Id = actorId, Name = "Actor One" }
        );

        var genreId = Guid.NewGuid();
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = genreId, Name = "Genre One" }
        );
    }



}
