using HLIMS_API_MicroServices.Data.Models.DynamoDB;
using HLIMS_API_MicroServices.Data.Models.Context;
using HLIMS_API_MicroServices.Data.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.Model;
using Newtonsoft.Json;
namespace HLIMS_API_MicroServices.Data
{
    public class CustomerDao: ICustomerDao
    {
         private readonly IDynamoDbContext<CustomerModel> _customerContext;
         private readonly string _customerDynamoTable;
         public CustomerDao(IConfiguration config,IDynamoDbContext<CustomerModel> customerContext)
         {
            _customerContext = customerContext;
            _customerDynamoTable = config.GetSection("DynamoDbTables:Customer").Value;
         }
          public async Task<List<Customer>> GetCustomerAsync(string bankName, string loanID, bool needCustNumFilter)
        {

            try
            {
                var customerList = new List<Customer>();
                var expressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    { ":BankName", new AttributeValue {
                        S = bankName
                    }}
                };
                var keyConditionExpression = "BankName = :BankName";
                if (needCustNumFilter)
                {
                    expressionAttributeValues.Add(":LoanID", new AttributeValue { S = loanID });
                    keyConditionExpression = string.Concat(keyConditionExpression, " and LoanID = :LoanID");
                }

                var queryRequest = new QueryRequest
                {
                    TableName = _customerDynamoTable,
                    ExpressionAttributeValues = expressionAttributeValues,
                    KeyConditionExpression = keyConditionExpression

                };

                var queryResponse = await _customerContext.QueryAsync(queryRequest);

                if (queryResponse != null)
                {
                    foreach (var item in queryResponse.Items)
                    {
                        customerList = customerList.Concat(JsonConvert.DeserializeObject<List<Customer>>(item["CustomerObject"].S)).ToList();
                    }

                }

                return customerList;
            }
           
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}