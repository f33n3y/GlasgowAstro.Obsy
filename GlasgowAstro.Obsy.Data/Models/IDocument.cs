using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GlasgowAstro.Obsy.Data.Models
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; }
    }
}
