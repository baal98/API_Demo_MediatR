using application.Commands;
using application.DataAccess;
using application.Models;
using application.Notification;
using MediatR;
using System;
using Microsoft.Extensions.Logging;

namespace application.Handlers
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;
        private readonly IMediator _mediator;
        private readonly ILogger<DeletePersonHandler> _logger;

        public DeletePersonHandler(IDataAccess data, IMediator mediator, ILogger<DeletePersonHandler> logger)
        {
            _data = data;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<PersonModel> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var deletedPerson = _data.DeletePerson(request.Id);

            if (deletedPerson != null)
            {
                _logger.LogInformation($"Person deleted: {deletedPerson.FirstName} {deletedPerson.LastName}");

                await _mediator.Publish(new PersonDeletedNotification { PersonId = deletedPerson.Id, FirstName = deletedPerson.FirstName, LastName = deletedPerson.LastName}, cancellationToken);
            }

            return await Task.FromResult(deletedPerson);
        }
    }
}