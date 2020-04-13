using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GlasgowAstro.Obsy.Data.Models
{
    public interface IDocument
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }
    }
}
