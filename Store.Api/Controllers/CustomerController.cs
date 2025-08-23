using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Handlers;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerHandler _handler;
        private readonly ICustomerRepository _repository;

        public CustomerController(CustomerHandler handler, ICustomerRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost("customers")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(new { message = result });
        }

        [HttpPut("customers/id:int")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(new { message = result });
        }

        [HttpDelete("customers/id:int")]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand command)

        {
            var result = await _handler.Handle(command);
            return Ok(new { message = "Deleted" });
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GeyAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(new { message = result });

        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GeyById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(new { message = result });
        }


    }

}
