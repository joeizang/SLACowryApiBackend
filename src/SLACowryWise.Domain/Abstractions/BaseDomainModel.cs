using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SLACowryWise.Domain.Abstractions
{
    public class BaseDomainModel
    {
        public BaseDomainModel()
        {
            CreatedAt = DateTimeOffset.UtcNow;
        }

        [BsonElement("CreatedAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}