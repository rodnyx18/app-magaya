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
    public class OrderController : ControllerBase
    {
        IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReponse>>> GetOrders()
        {
            var orders = await _repository.GetAll();

            return Ok(orders.Select(o => o.ToOrderReponse()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReponse?>> GetOrder(int id)
        {
            var order = await _repository.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            var products = await _repository.GetProductOrder(id);
            order.ProductOrders = products;
            order.CalculateTotalValue();         

            return Ok(order.ToOrderReponse());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderRequest orderRequete)
        {
            if (id != orderRequete.Id)
            {
                return BadRequest();
            }

            await _repository.Update(id , orderRequete.ToOrder());

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<OrderReponse>> PostOrder(OrderRequest orderRequete)
        {
            var order = await _repository.Add(orderRequete.ToOrder());

            return CreatedAtAction("GetOrder", new { id = order.Id }, order.ToOrderReponse());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
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
