using GlasgowAstro.Obsy.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Data
{
    public interface IRepository<TDocument> where TDocument : IDocument
    {
        Task<TDocument> FindByIdAsync(string id);

        Task InsertManyAsync(ICollection<TDocument> documents);
    }
}
