using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Dtos;
using Store.Application.Handlers;
using Store.Application.Commands;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Interfaces;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryHandler _handler;
        private readonly IDeliveryRepository _repository;

        private readonly IOrderRepository _ordemrepository;
        public DeliveryController(DeliveryHandler handler, IDeliveryRepository repository, IOrderRepository ordemrepository)
        {
            _handler = handler;
            _repository = repository;
            _ordemrepository = ordemrepository;
        }

        [HttpPost("deliveries")]
        public async Task<IActionResult> Create([FromBody] CreateDeliveryCommand command)
        {
            var result = await _handler.Handle(command);
            var order = await _ordemrepository.GetByIdAsync(command.OrderId);
            if (order == null) return NotFound("Invalid order id");

            var dto = new DeliveryDto
            {
                OrderId = order.Id,
                Payment = true

            };
            return Ok(dto);
        }

        [HttpGet("deliveries/id:int")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("deliveries")]
        public async Task<IActionResult> GetlAll()
        {
            return Ok(await _repository.GetAllAsync());
        }
    }
}