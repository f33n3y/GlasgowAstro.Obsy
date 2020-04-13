using GlasgowAstro.Obsy.Data.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Data.Abstractions
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        Task InsertManyAsync(ICollection<TDocument> documents);

        Task BulkWriteAsync(IEnumerable<WriteModel<TDocument>> documents);

        Task DeleteManyAsync(FilterDefinition<TDocument> filter);
    }
}
