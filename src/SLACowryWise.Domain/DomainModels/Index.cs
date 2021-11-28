using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Indexes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLACowryWise.Domain.DomainModels
{
    public class IndexAssets : BaseDomainModel
    {
        public IndexAssetsResponse IndexAssetsResponse { get; set; }
    }

    public class CustomIndex : BaseDomainModel
    {
        public CustomIndexResponse CustomIndexResponse { get; set; }
    }

    public class CustomIndexUpdate : BaseDomainModel
    {
        public UpdateCustomIndexResponse UpdateCustomIndexResponse { get; set; }
    }


}
