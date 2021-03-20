
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult Getall()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _customerService.GetCustomerDetails();
                if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // customer getall eklenecek ve ekrana verilecek service hazır sadece son 3 ödev yapılacak  
    }
}
