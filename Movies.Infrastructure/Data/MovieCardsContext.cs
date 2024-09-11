using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Movies.Infrastructure.Data
{
    public class MovieCardsContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Director> Directors { get; set; }
        public DbSet<ApplicationUser> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

        public MovieCardsContext(DbContextOptions<MovieCardsContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationships
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

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
                .HasForeignKey<Director>(d => d.ContactInformationId);

            // Configure foreign key constraints with cascading delete options
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Movie)
                .WithMany()
                .HasForeignKey(u => u.MovieId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.ContactInformation)
                .WithMany()
                .HasForeignKey(u => u.ContactInformationId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete

            // Seed ContactInformation
            var contactInformationId = Guid.NewGuid();
            modelBuilder.Entity<ContactInformation>().HasData(
                new ContactInformation
                {
                    Id = contactInformationId,
                    Email = "director@example.com",
                    PhoneNumber = "555-1234"
                }
            );

            // Seed Director first
            var directorId = Guid.NewGuid();
            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Id = directorId,
                    Name = "Director One",
                    DateOfBirth = new DateTime(1970, 1, 1),
                    ContactInformationId = contactInformationId // Link to valid ContactInformation
                }
            );

            // Seed Movie after Director
            var movieId = Guid.NewGuid();
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = movieId,
                    Title = "Movie One",
                    ReleaseDate = new DateTime(2020, 1, 1),
                    DirectorId = directorId, // Use valid DirectorId
                    Rating = 0, // Ensure default or valid value
                    Description = null // Or provide a valid description
                }
            );

            // Seed ApplicationUser (Actor One)
            var actorId = Guid.NewGuid().ToString();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = actorId,
                    Name = "Actor One",
                    ContactInformationId = contactInformationId, // Link to valid ContactInformation
                    MovieId = movieId // Link to valid Movie
                }
            );
        }


        /*private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed ContactInformation
            var contactInformationId = Guid.NewGuid();
            modelBuilder.Entity<ContactInformation>().HasData(
                new ContactInformation
                {
                    Id = contactInformationId,
                    Email = "director@example.com",
                    PhoneNumber = "555-1234"
                }
            );

            // Seed Director data
            var directorId = Guid.NewGuid();
            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Id = directorId,
                    Name = "Director One",
                    DateOfBirth = new DateTime(1970, 1, 1),
                    ContactInformationId = contactInformationId // Link to valid ContactInformation
                }
            );

            // Seed Movie data
            var movieId = Guid.NewGuid();
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = movieId,
                    Title = "Movie One",
                    ReleaseDate = new DateTime(2020, 1, 1)
                }
            );

            // Seed ApplicationUser (Actor)
            var actorId = Guid.NewGuid().ToString();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = actorId,
                    Name = "Actor One",
                    ContactInformationId = contactInformationId, // Link to valid ContactInformation
                    MovieId = movieId // Link to valid Movie
                }
            );
        }*/
    }
}
