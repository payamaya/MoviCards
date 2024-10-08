﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Domain.Models.Entities
{
    public class ApplicationUser :IdentityUser
    {
        //[Key]
        //public Guid Id { get; set; }
        public string? Name { get; set; }

        // Foreign Key for ContactInformation
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
        // Foreign key for ContactInformation
        public Guid ContactInformationId { get; set; }

        // Navigation property
        public ContactInformation ContactInformation { get; set; }

        // Navigation property for the many-to-many relationship with Movies
        public ICollection<MovieActor>? MovieActors { get; set; } = new List<MovieActor>();

    }
}