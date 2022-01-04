using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SLACowryWise.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SLACowryWise.Domain.DomainModels
{

    public class CowryBanks
    {
        public List<Bank> Banks { get; set; }

        [BsonElement("CreatedAt")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
    }
}
