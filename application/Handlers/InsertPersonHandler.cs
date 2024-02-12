using application.Commands;
using application.DataAccess;
using application.Models;
using application.Notifications;
using MediatR;

namespace application.Handlers
{
    public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;
        private readonly IMediator _mediator;

        public InsertPersonHandler(IDataAccess data, IMediator mediator)
        {
            _data = data;
            _mediator = mediator;
        }

        public async Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            PersonModel person = _data.InsertPerson(request.FirstName, request.LastName);
            await WritePersonToFileAsync(person);

            await _mediator.Publish(new PersonCreatedNotification { Person = person }, cancellationToken);

            return person;
        }


        public async Task WritePersonToFileAsync(PersonModel person)
        {
            string filePath = "people.txt";
            string personData = $"{person.Id}, {person.FirstName}, {person.LastName}{Environment.NewLine}";

            await File.AppendAllTextAsync(filePath, personData);
        }


    }
}
