using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Handlers.Interfaces;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerHandler _handler;

        public CustomerController(CustomerHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("customers")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(new { message = result });

        }
    }
}