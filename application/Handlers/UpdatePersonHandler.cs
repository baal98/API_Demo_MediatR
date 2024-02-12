using application.Commands;
using application.DataAccess;
using application.Models;
using application.Notification;
using MediatR;

namespace application.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;
        private readonly IMediator _mediator;

        public UpdatePersonHandler(IDataAccess data, IMediator mediator)
        {
            _data = data;
            _mediator = mediator;
        }

        public async Task<PersonModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _data.UpdatePerson(request.Id, request.FirstName, request.LastName);

            if (person != null)
            {
                await _mediator.Publish(new PersonUpdatedNotification { Person = person }, cancellationToken);
            }

            return person;
        }
    }
}