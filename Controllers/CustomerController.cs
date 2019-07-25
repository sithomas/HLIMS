using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HLIMS_API_MicroServices.Data.Models;
using HLIMS_API_MicroServices.Domain.Services;
using HLIMS_API_MicroServices.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HLIMS_API_MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            
            _customerService= customerService;
        }
       


        //POST: v1/customer/bank/{bankName}/loan/{loanID}
        [HttpGet]
        [Route("bank/{bankName}/loan/{loanID}")]
        public async Task<ActionResult> GetCustomerAsync([FromRoute(Name = "bankName")] string bankName, [FromRoute(Name = "loanID")] string loanID)
        {
            try
            {

               
                var result = await _customerService.GetCustomerAsync(bankName, loanID);
                if (!result.Response.RequestSuccessful)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, result.Response.ErrorMessage);
                }

                var data = new ResponseMessage<List<Customer>>(result.ResponseObject.Count, result.ResponseObject);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}