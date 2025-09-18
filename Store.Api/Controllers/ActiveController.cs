
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.UseCases.Active;



namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ActiveController : ControllerBase
    {
        private readonly IRequestHandler<Request, Response> _handler;

        public ActiveController(IRequestHandler<Request, Response> handler)
        {
            _handler = handler;
        }

        [HttpPost("auth/active")]
        public async Task<IActionResult> ActivateUser([FromBody] Request request)
        {
            var response = await _handler.Handle(request, CancellationToken.None);
            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }
    }
}