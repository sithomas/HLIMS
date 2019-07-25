using System.Collections.Generic;
using System.Threading.Tasks;
using HLIMS_API_MicroServices.Data.Models;
using HLIMS_API_MicroServices.Responses;

namespace HLIMS_API_MicroServices.Domain.Services
{
    public interface ICustomerService
    {
        Task<BaseResponse<List<Customer>>> GetCustomerAsync(string bankName, string loanID);
    }
}