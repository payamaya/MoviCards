namespace Domain.Models.Exceptions;


       public class ActorNotFoundException : NotFoundException
           {
           public ActorNotFoundException(Guid id) : base($"The Actor with id: {id} was notfound") 
           { 
           }
       }
    

