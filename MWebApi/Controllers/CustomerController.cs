using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWebApi.Dto.Requete;
using MWebApi.Dto.Reponse;
using MWebApi.Mapping;
using MWebApi.Repositories;

namespace MWebApi.Controllers
{   

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReponse>>> GetCustomers()
        {
            var customers = await _repository.GetAll();

            return customers.Select(c => c.ToCustomerReponse()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReponse?>> GetCustomer(int id)
        {
            var customer = await _repository.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer.ToCustomerReponse());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerRequete requete)
        {
            if (id != requete.Id)
            {
                return BadRequest();
            }

            await _repository.Update(id , requete.ToCustomer());

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CustomerReponse>> PostCustomer(CustomerRequete requete)
        {
            var customer = await _repository.Add(requete.ToCustomer());

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer.ToCustomerReponse());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
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
