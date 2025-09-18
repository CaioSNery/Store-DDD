using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Store.Application.Commands;
using Store.Domain.Entities;
using Store.Application.Handlers;
using Store.Domain.Repositories;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        private readonly ProductHandler _handler;
        private readonly IProductRepository _repository;

        public ProductController(ProductHandler handler, IProductRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost("products")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(new { message = result });
        }

        [HttpDelete("products/id:int")]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(new { message = result });
        }

        [HttpPut("products/id:int")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await _handler.Handle(command);
            return Ok(new { message = result });
        }

        [HttpGet("products/id:int")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            return Ok(new { message = result });
        }

        [HttpGet("products/ids/id:int")]
        public async Task<IActionResult> GetBysIdsList([FromQuery] IEnumerable<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return BadRequest("At least one Id must be provided");

            var products = await _repository.GetAsync(ids);

            if (products == null || !products.Any())
                return NotFound("No products found");

            return Ok(products);
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);

        }


    }
}