using application.Models;
using MediatR;

namespace application.Queries
{
    public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;
}
