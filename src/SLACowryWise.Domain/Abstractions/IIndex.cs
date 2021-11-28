using SLACowryWise.Domain.DTOs.Indexes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IIndex
    {
        Task<IndexPaginatedResponse> GetIndexes(GetPaginatedResponseInputModel inputModel);

        Task<IndexAssetsResponse> GetIndexAssets(string indexId);

        Task<SingleIndexResponse> GetSingleIndex(string indexId);

        Task<CustomIndexResponse> CreateCustomIndex(CustomIndexInputModel inputModel);

        Task<UpdateCustomIndexResponse> UpdateCustomIndex(UpdateCustomIndexInputModel inputModel);
    }
}
