using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Assets;

namespace SLACowryWise.Domain.Services
{
    public class AssetsService : IAssetsService
    {
        private readonly IHttpService _assetService;

        public AssetsService(IHttpService assetService)
        {
            _assetService = assetService;
        }
        public async Task<AssetsPaginatedResponse> GetAllAssets(AssetsPaginatedResponseInput inputModel = null)
        {
            IRestRequest request = new RestRequest("/api/v1/assets", Method.GET);
            if (inputModel is not null)
            {
                request.AddParameter("country", inputModel.Country, ParameterType.GetOrPost);
                request.AddParameter("asset_type", inputModel.AssetType, ParameterType.GetOrPost);
                request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
                request.AddParameter("page_size", inputModel.PageSize, ParameterType.GetOrPost);
            }

            var client = await _assetService.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<AssetsPaginatedResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SingleAssetRoot> GetSingleAsset(string id)
        {
            IRestRequest request = new RestRequest($"/api/v1/assets{id}", Method.GET);
            var client = await _assetService.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SingleAssetRoot>(request).ConfigureAwait(false);
            return result.Data;
        }

    }
}