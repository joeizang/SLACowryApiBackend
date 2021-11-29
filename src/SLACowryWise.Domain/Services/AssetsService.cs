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
        public async Task<AssetsPaginatedResponse> GetAllAssets(AssetsPaginatedResponseInput inputModel)
        {
            IRestRequest request;
            //var page = inputModel.Page is not null ? int.Parse(inputModel.Page) : 0;

            //if(page > 1)
            //    request = new RestRequest($"/api/v1/assets?page={page}", Method.GET);
            //else
            request = new RestRequest($"/api/v1/assets", Method.GET);
            if (inputModel is not null && string.IsNullOrEmpty(inputModel.Page) && string.IsNullOrEmpty(inputModel.PageSize)
                && string.IsNullOrEmpty(inputModel.Country) && string.IsNullOrEmpty(inputModel.AssetType))
            {
                var httpClient = await _assetService.InitializeClient().ConfigureAwait(false);
                var assetResult = await httpClient.ExecuteAsync<AssetsPaginatedResponse>(request)
                    .ConfigureAwait(false);
                return assetResult.Data;
            }
            if (inputModel is not null && !string.IsNullOrEmpty(inputModel.Page) && string.IsNullOrEmpty(inputModel.PageSize)
                && string.IsNullOrEmpty(inputModel.Country) && string.IsNullOrEmpty(inputModel.AssetType))
            {
                request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
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