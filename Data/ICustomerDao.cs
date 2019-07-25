using HLIMS_API_MicroServices.Data.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace HLIMS_API_MicroServices.Data
{
    public interface ICustomerDao
    {
        Task<List<Customer>> GetCustomerAsync(string bankName, string loanID, bool needCustNumFilter);
    }
}