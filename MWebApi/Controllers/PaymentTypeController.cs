using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWebApi.Dto.Reponse;
using MWebApi.Mapping;
using MWebApi.Repositories;

namespace MWebApi.Controllers
{   

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        IPaymentTypeRepository _repository;

        public PaymentTypeController(IPaymentTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTypeReponse>>> GetPaymentTypes()
        {
            var payments = await _repository.GetAll();

            var reponse = payments.Select(x => x.ToPaymentTypeReponse()).ToList();

            return Ok(reponse);
        }    
    }
}
