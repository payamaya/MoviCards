/*using Microsoft.EntityFrameworkCore;
using MovieCardsAPI.Models.Entities;

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
        // Configure the many-to-many relationship between Movie and Actor
        modelBuilder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });

        modelBuilder.Entity<MovieActor>()
            .HasOne(ma => ma.Movie)
            .WithMany(m => m.MovieActors)
            .HasForeignKey(ma => ma.MovieId);

        modelBuilder.Entity<MovieActor>()
            .HasOne(ma => ma.Actor)
            .WithMany(a => a.MovieActors)
            .HasForeignKey(ma => ma.ActorId);

        // Configure the many-to-many relationship between Movie and Genre
        modelBuilder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId });

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(mg => mg.MovieId);

        modelBuilder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);

        // Configure the one-to-many relationship between Movie and Director
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Director)
            .WithMany(d => d.Movies)
            .HasForeignKey(m => m.DirectorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the one-to-one relationship between Director and ContactInformation
        modelBuilder.Entity<Director>()
            .HasOne(d => d.ContactInformation)
            .WithOne(ci => ci.Director)
            .HasForeignKey<ContactInformation>(ci => ci.DirectorId);

        // Other configurations
        modelBuilder.Entity<Actor>()
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Genre>()
            .Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<ContactInformation>()
            .Property(ci => ci.Email)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<ContactInformation>()
            .Property(ci => ci.PhoneNumber)
            .IsRequired();

      *//*  modelBuilder.Entity<Movie>()
            .HasMany(d=>d.MovieActors)
            .WithMany(a=>a.MovieId)
            .UsingEntity<Movie>(
            )*//*

    }
  

}
*/
using Microsoft.EntityFrameworkCore;
using MovieCardsAPI.Models.Entities;

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

        // Configure one-to-one relationship between Director and ContactInformation
        modelBuilder.Entity<Director>()
            .HasOne(d => d.ContactInformation)
            .WithOne(ci => ci.Director)
            .HasForeignKey<ContactInformation>(ci => ci.DirectorId);

        // Seed data for testing
        modelBuilder.Entity<Director>().HasData(
            new Director { Id = 1, Name = "Director One", DateOfBirth = new DateTime(1970, 1, 1) }
            // Add more seeding here
        );

        // Add seeding for Movies, Actors, Genres, and ContactInformations as needed.
    }
}
