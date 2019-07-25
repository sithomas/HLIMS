using Amazon.DynamoDBv2.DataModel;
namespace HLIMS_API_MicroServices.Data.Models.DynamoDB
{
    public class CustomerModel
    {

        [DynamoDBHashKey]
        public string BankName { get; set; }

        [DynamoDBRangeKey]
        public int LoanID { get; set; }

        [DynamoDBProperty]
        public string CustomerObject { get; set; }
    }
}