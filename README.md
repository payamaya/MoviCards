   # Movie Crads API
   
  The primary objective is to build a robust .NET API using EF Core to manage movies, directors, actors,
  and genres, with a strict focus on exposing data only through DTOs.


   ## Required Entities:
   **Movie:**
      Id, Title, Rating, ReleaseDate, Description
   **Relationships:**
   - One-to-Many with Director.
   - Many-to-Many with Actor.
   - Many-to-Many with Genre
   **Director:**
      Id, Name, DateOfBirth
   **Relationship:**
   - One-to-One with ContactInformation.
   **Actor:**
      Id, Name, DateOfBirth  
   **Genre:**
   Id, Name
   **ContactInformation:**
      Id, Email, PhoneNumber

      ## These endpoints are a minimum of what you should implement
      **Movie:**
      - GET /api/movies: Return a list of MovieDTO.
      - GET /api/movies/{id}: Return a single MovieDTO by ID.
      - POST /api/movies: Create a new movie using a MovieForCreationDTO.
      - PUT /api/movies/{id}: Update an existing movie with a MovieForUpdateDTO.
      - DELETE /api/movies/{id}: Delete a movie by ID

      **Get Detailed Movie Information:**
      - GET /api/movies/{id}/details: Return a MovieDetailsDTO that combines data from Movie,
      Director, ContactInformation, Genre, and Actor

## Validation and setup

All tables should be seeded with random test data.  

Add validation for creating and updating a movie.  

API should return correct status codes!

## Extra

Integrate the new `MovieDetails` endpoint into the existing movie card exercise, just for display from the API.  

Implement more endpoints for more of the other entities.  

Implement "Add New Movie" from the React app.
