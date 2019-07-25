using System;
namespace HLIMS_API_MicroServices.Data.Models
{
    public class Customer
    {
       public string BankName {get;set;}
       public string LoanID {get;set;}
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string StreetAddress { get; set; }
        public string MailingAddress { get; set; }
        public string Gender { get; set; }
    }
}
