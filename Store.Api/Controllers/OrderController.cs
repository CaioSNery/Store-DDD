using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Repository;
using Store.Application.Dtos;
using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Handlers;
using Store.Domain.Repositories;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class OrderController : ControllerBase
    {
        private readonly OrderHandler _handler;
        private readonly IOrderRepository _repository;


        public OrderController(OrderHandler handler, IOrderRepository repository)
        {
            _handler = handler;
            _repository = repository;

        }


        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(new { message = result });

        }

        [HttpDelete("orders/id:int")]
        public async Task<IActionResult> DeleteOrder([FromBody] DeleteOrderCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(new { message = result });
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrder()
        {
            var result = await _repository.GetAllAsync();
            return Ok(new { message = result });
        }

        [HttpGet("orders/id:int")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null) return NotFound("Invalid id");

            var dto = new OrderDto
            {
                Id = result.Id,
                Number = result.Number,
                CustomerName = result.Customer.Name,
                CustomerId = result.CustomerId
            };

            return Ok(dto);
        }
    }
}