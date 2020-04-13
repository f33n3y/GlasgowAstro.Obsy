using GlasgowAstro.Obsy.Data.Abstractions;
using GlasgowAstro.Obsy.Data.Attributes;
using GlasgowAstro.Obsy.Data.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Data
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument>
        where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IConfiguration configuration)
        {
            var database = new MongoClient(configuration["MongoDbConnection:ConnectionString"])
                .GetDatabase(configuration["MongoDbConnection:Database"]);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public virtual async Task BulkWriteAsync(IEnumerable<WriteModel<TDocument>> documents)
        {
            BulkWriteResult res = await _collection.BulkWriteAsync(documents, new BulkWriteOptions { IsOrdered = false });
        }

        public virtual async Task DeleteManyAsync(FilterDefinition<TDocument> filter)
        {
            await _collection.DeleteManyAsync(filter);
        }
    }
}
