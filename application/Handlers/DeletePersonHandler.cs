using application.Commands;
using application.DataAccess;
using application.Models;
using application.Notification;
using MediatR;

namespace application.Handlers
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;
        private readonly IMediator _mediator;

        public DeletePersonHandler(IDataAccess data, IMediator mediator)
        {
            _data = data;
            _mediator = mediator;
        }

        public async Task<PersonModel> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var deletedPerson = _data.DeletePerson(request.Id);

            if (deletedPerson != null)
            {
                await _mediator.Publish(new PersonDeletedNotification { PersonId = deletedPerson.Id, FirstName = deletedPerson.FirstName, LastName = deletedPerson.LastName}, cancellationToken);
            }

            return await Task.FromResult(deletedPerson);
        }
    }
}