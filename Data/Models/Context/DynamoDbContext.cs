using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System.Threading.Tasks;

namespace HLIMS_API_MicroServices.Data.Models.Context
{
    public class DynamoDbContext<T> : DynamoDBContext, IDynamoDbContext<T> where T : class
    {

        private readonly DynamoDBOperationConfig _config;
        private readonly IAmazonDynamoDB _client;

        private readonly string _tableName;

        public DynamoDbContext(IAmazonDynamoDB client, string tableName) : base(client)
        {
            _client = client;
            _tableName = tableName;
            _config = new DynamoDBOperationConfig()
            {
                OverrideTableName = tableName
            };
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await base.LoadAsync<T>(id, _config);
        }

        public async Task SaveAsync(T item) 
        {
            await base.SaveAsync(item, _config);
        }

        public async Task DeleteByIdAsync(T item)
        {
            await base.DeleteAsync(item, _config);
        }

        public async Task<QueryResponse> QueryAsync(QueryRequest queryRequest)
        {
            return await _client.QueryAsync(queryRequest);
        }

    }

}