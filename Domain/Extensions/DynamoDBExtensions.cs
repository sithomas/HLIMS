using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using HLIMS_API_MicroServices.Data.Models.Context;
using HLIMS_API_MicroServices.Data.Models.DynamoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HLIMS_API_MicroServices.Domain.Extensions
{
    public static class DynamoDBExtensions
    {
        public static void AddDynamoDbObjects(this IServiceCollection services, IConfiguration configuration)
        {
            
            var accessKey = configuration.GetValue<string>("DynamoDB:AccessKey");
            var securityKey = configuration.GetValue<string>("DynamoDB:SecurityKey");
            var credentials = new BasicAWSCredentials(accessKey, securityKey);
            var regionEndpoint = RegionEndpoint.GetBySystemName(configuration.GetValue<string>("DynamoDB:Region"));
            var client = new AmazonDynamoDBClient(credentials, regionEndpoint);
            var dynamoDbOptions = new DynamoDBOptions();
            ConfigurationBinder.Bind(configuration.GetSection("DynamoDbTables"), dynamoDbOptions);
            services.AddScoped<IDynamoDbContext<CustomerModel>>(provider => new DynamoDbContext<CustomerModel>(client, dynamoDbOptions.Customer));

        }
    }
}