using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SLACowryWise.Domain.DomainModels
{
    public class AccountAssets : BaseDomainModel
    {
        public AssetsPaginatedResponseDto AssetsPaginatedResponse { get; set; }
    }

    public class AssetsPagedDataResponse : BaseDomainModel
    {
        public AssetsPaginatedDto AssetsPaginatedDto { get; set; }
    }

    public class SingleAssetData : BaseDomainModel
    {
        public SingleAssetsResponse SingleAssetsResponse { get; set; }
    }

    public class CachedAssets
    {
        public List<SingleAssetsResponse> Assets { get; set; }

        [BsonElement("CreatedAt")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
    }

}
