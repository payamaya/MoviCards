namespace Domain.Models.Exceptions;

     public class MovieNotFoundException : NotFoundException
     {
         public MovieNotFoundException(Guid id) : base($"The Movie with id : {id}wasnotfound") 
         { 
         }
     }
   
