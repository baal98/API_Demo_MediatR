using application.Commands;
using application.DataAccess;
using application.Models;
using MediatR;

namespace application.Handlers
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, PersonModel>
    {
        private readonly IDataAccess _data;

        public DeletePersonHandler(IDataAccess data)
        {
            _data = data;
        }
        public async Task<PersonModel> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data.DeletePerson(request.Id));
        }
    }
}
