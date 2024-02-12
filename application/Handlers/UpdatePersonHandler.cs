using application.Commands;
using application.DataAccess;
using application.Models;
using MediatR;

namespace application.Handlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;

        public UpdatePersonHandler(IDataAccess data)
        {
            _data = data;
        }

        public async Task<PersonModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data.UpdatePerson(request.Id, request.FirstName, request.LastName));
        }
    }
}
