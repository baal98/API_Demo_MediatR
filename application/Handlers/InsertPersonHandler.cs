using application.Commands;
using application.DataAccess;
using application.Models;
using application.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace application.Handlers
{
    public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;
        private readonly IMediator _mediator;
        private readonly ILogger<InsertPersonHandler> _logger;


        public InsertPersonHandler(IDataAccess data, IMediator mediator, ILogger<InsertPersonHandler> logger)
        {
            _data = data;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            PersonModel person = _data.InsertPerson(request.FirstName, request.LastName);
            await WritePersonToFileAsync(person);

            _logger.LogInformation($"New person created: {person.FirstName} {person.LastName}");

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
