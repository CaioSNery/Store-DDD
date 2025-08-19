using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands;
using Store.Domain.Handlers;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class OrderController : ControllerBase
    {
        private readonly OrderHandler _handler;

        public OrderController(OrderHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(new { message = result });
        }
    }
}