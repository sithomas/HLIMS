using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HLIMS_API_MicroServices.Data;
using HLIMS_API_MicroServices.Data.Models;
using HLIMS_API_MicroServices.Responses;
using HLIMS_API_MicroServices.Domain.Services;
namespace HLIMS_API_MicroServices.Domain.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerDao _customerDao;

        public CustomerService(
            ICustomerDao customerDao)
        {

            _customerDao = customerDao
                ??
                throw new System.ArgumentNullException(nameof(customerDao));
        }


        public async Task<BaseResponse<List<Customer>>> GetCustomerAsync(string bankName  , string loanID)
        {
            try
            {
                List<Customer> customerList = new List<Customer>();
                
                customerList = await _customerDao.GetCustomerAsync(bankName, loanID, true);

                return new BaseResponse<List<Customer>>(customerList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}