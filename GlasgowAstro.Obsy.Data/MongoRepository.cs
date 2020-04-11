using GlasgowAstro.Obsy.Data.Attributes;
using GlasgowAstro.Obsy.Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Data
{
    public class MongoRepository<TDocument> : IRepository<TDocument>
        where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository()
        {
            var db = new MongoClient("").GetDatabase(""); // TODO Pull from appsettings
            _collection = db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public Task<TDocument> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }

        public Task<TDocument> FindByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }

    }
}

// _config["MongoDbConnection:ConnectionString"];
// _config["MongoDbConnection:Database"];

