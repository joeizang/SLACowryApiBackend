using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Assets;
using System;
using System.Collections.Generic;
using System.Text;

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

}
