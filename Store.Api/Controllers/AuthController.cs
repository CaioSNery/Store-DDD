
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Extensions;
using Store.Application.UseCases.Authenticate;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AuthController : ControllerBase
    {
        private readonly IRequestHandler<Request, Response> _handler;

        public AuthController(IRequestHandler<Request, Response> handler)
        {
            _handler = handler;
        }


        [HttpPost("auth/login")]
        public async Task<IActionResult> Login([FromBody] Request request)
        {
            var response = await _handler.Handle(request, new CancellationToken());

            if (!response.IsSuccess)
                return new JsonResult(response) { StatusCode = response.Status };

            if (response.Data is null)
                return new JsonResult(response) { StatusCode = 500 };

            response.Data.Token = ExtensionJwT.Generate(response.Data);
            return new JsonResult(response) { StatusCode = 200 };
        }
    }
}