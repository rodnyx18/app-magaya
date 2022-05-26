using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWebApi.Dtos.Request;
using MWebApi.Dtos.Reponse;
using MWebApi.Mapping;
using MWebApi.Repositories;

namespace MWebApi.Controllers
{   

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReponse>>> GetProducts()
        {
            var products = await _repository.GetAll();

            return products.Select(p => p.ToProductReponse()).ToList();
        }

        [HttpGet("search/{text}")]
        public async Task<ActionResult<IEnumerable<ProductReponse>>> GetProducts(string text)
        {
            var products = await _repository.GetAll(text);

            return products.Select(p => p.ToProductReponse()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReponse?>> GetProduct(int id)
        {
            var product = await _repository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.ToProductReponse());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductRequest productRequete)
        {
            if (id != productRequete.Id)
            {
                return BadRequest();
            }

            await _repository.Update(id , productRequete.ToProduct());

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductReponse>> PostProduct(ProductRequest productRequete)
        {
            var product = await _repository.Add(productRequete.ToProduct());

            return CreatedAtAction("GetProduct", new { id = product.Id }, product.ToProductReponse());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _repository.Delete(id);
            
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }       
    }
}
