using MongoDB.Bson;
using System;

namespace GlasgowAstro.Obsy.Data.Models
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
    }
}
