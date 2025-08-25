using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Handlers;
using Store.Domain.Commands;
using Store.Domain.Repositories.Interfaces;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class DeliveryController : ControllerBase
    {
        private readonly DeliveryHandler _handler;
        private readonly IDeliveryRepository _repository;

        public DeliveryController(DeliveryHandler handler, IDeliveryRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost("deliveries")]
        public async Task<IActionResult> Create([FromBody] CreateDeliveryCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(result);
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