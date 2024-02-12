using application.Models;
using MediatR;

namespace application.Queries
{
    public record GetPersonListQuery() : IRequest<List<PersonModel>>;
}
