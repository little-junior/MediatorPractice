using MediatorPractice.Application.UseCases.Commands.CreateUser;
using MediatorPractice.Application.UseCases.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorPractire.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute]Guid id, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery { Id = id };

            var gotUser = await _mediator.Send(query, cancellationToken);

            return Ok(gotUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            var createdUser = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }
    }
}
