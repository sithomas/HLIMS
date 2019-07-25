using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HLIMS_API_MicroServices.Data.Models.Context
{
    public interface IDynamoDbContext<T> : IDisposable where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task SaveAsync(T item);
        Task    DeleteByIdAsync(T item);
        Task<QueryResponse> QueryAsync(QueryRequest queryRequest);
    }
}