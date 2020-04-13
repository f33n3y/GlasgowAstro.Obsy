using GlasgowAstro.Obsy.Data.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Data.Abstractions
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        Task InsertManyAsync(ICollection<TDocument> documents);

        Task UpdateOrInsertManyAsync(ICollection<TDocument> documents,
            FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update);

        Task DeleteManyAsync(FilterDefinition<TDocument> filter);
    }
}
