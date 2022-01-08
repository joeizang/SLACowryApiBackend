using SLACowryWise.Domain.DTOs.Assets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IAssetsService
    {
        Task<AssetsPaginatedResponse> GetAllAssets(AssetsPaginatedResponseInput inputModel);
        Task<SingleAssetRoot> GetSingleAsset(string id);

        Task<List<AssetsPayload>> GetCahedAssets();
    }

    public interface ICachedAssetsService
    {
        string CollectionName { get; set; }

        Task<List<AssetsPayload>> GetDocsAsync();
    }
}