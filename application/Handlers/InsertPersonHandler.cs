using application.Commands;
using application.DataAccess;
using application.Models;
using MediatR;

namespace application.Handlers
{
    public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;

        public InsertPersonHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            PersonModel person = _data.InsertPerson(request.FirstName, request.LastName);
            WritePersonToFile(person);
            return Task.FromResult(person);
        }

        public void WritePersonToFile(PersonModel person)
        {
            string filePath = "people.txt";
            string personData = $"{person.Id}, {person.FirstName}, {person.LastName}{Environment.NewLine}";

            File.AppendAllText(filePath, personData);
        }

    }
}
