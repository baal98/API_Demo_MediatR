using application.Models;
using MediatR;

namespace application.Commands
{
    public record DeletePersonCommand(int Id) : IRequest<PersonModel>;
}
