using application.Commands;
using application.DataAccess;
using application.Models;
using application.Notification;
using MediatR;
using Microsoft.Extensions.Logging;

namespace application.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;
        private readonly IMediator _mediator;
        private readonly ILogger<UpdatePersonHandler> _logger;

        public UpdatePersonHandler(IDataAccess data, IMediator mediator, ILogger<UpdatePersonHandler> logger)
        {
            _data = data;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<PersonModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _data.UpdatePerson(request.Id, request.FirstName, request.LastName);

            if (person != null)
            {
                _logger.LogInformation($"Person updated: {person.FirstName} {person.LastName}");
                await _mediator.Publish(new PersonUpdatedNotification { Person = person }, cancellationToken);
            }

            return person;
        }
    }
}