using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.DTOs.Assets;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IAssetsService
    {
        Task<AssetsPaginatedResponse> GetAllAssets(AssetsPaginatedResponseInput inputModel);
        Task<SingleAssetRoot> GetSingleAsset(string id);
    }
}