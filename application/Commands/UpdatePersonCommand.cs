using application.Models;
using MediatR;

namespace application.Commands
{
    //public record UpdatePersonCommand(int id, string FirstName, string LastName) : IRequest<PersonModel>;

    public class UpdatePersonCommand : IRequest<PersonModel>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UpdatePersonCommand(int id, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

    }
}
