using application.Commands;
using application.Models;
using application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<List<PersonModel>> Get()
        {
            return await _mediator.Send(new GetPersonListQuery());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<PersonModel> Get(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<PersonModel> Post([FromBody] PersonModel value)
        {
            return await _mediator.Send(new InsertPersonCommand(value.FirstName, value.LastName));
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<PersonModel> Put(int id, [FromBody] PersonModel value)
        {
            return await _mediator.Send(new UpdatePersonCommand(id, value.FirstName, value.LastName));
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<PersonModel> Delete(int id)
        {
            return await _mediator.Send(new DeletePersonCommand(id));
        }
    }
}