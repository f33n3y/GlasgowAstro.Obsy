using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GlasgowAstro.Obsy.Data.Models
{
    public abstract class Document : IDocument
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
    }
}
