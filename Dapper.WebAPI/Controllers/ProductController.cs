using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Core.Entity;
using Dapper.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            return StatusCode(201);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _unitOfWork.Products.UpdateAsync(product);
            return NoContent();
        }
    }
}
