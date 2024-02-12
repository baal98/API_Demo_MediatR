using application.Models;
using MediatR;

namespace application.Commands
{
    //public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;

    public class InsertPersonCommand : IRequest<PersonModel>
    {
        private string firstName;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
            }
        }
        public string LastName { get; set; }

        public InsertPersonCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
