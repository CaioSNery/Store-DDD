
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.UseCases.Create;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UserController : ControllerBase
    {
        private readonly IRequestHandler<Request, Response> _handler;

        public UserController(IRequestHandler<Request, Response> handler)
        {
            _handler = handler;
        }

        [HttpPost("user/create")]
        public async Task<IActionResult> CreateUser([FromBody] Request request)
        {
            var response = await _handler.Handle(request, CancellationToken.None);

            if (response.Status == 201) // criado
                return CreatedAtAction(nameof(CreateUser), new { id = response.Data.Id }, response);

            return BadRequest(response);
        }
    }
}