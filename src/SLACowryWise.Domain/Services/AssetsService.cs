using MongoDB.Driver;
using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DTOs.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class AssetsService : IAssetsService
    {
        private readonly ICachedAssetsService _assets;
        private readonly IHttpService _assetService;

        public AssetsService(IHttpService assetService, ICachedAssetsService assets)
        {
            _assets = assets;
            _assetService = assetService;
        }
        public async Task<AssetsPaginatedResponse> GetAllAssets(AssetsPaginatedResponseInput inputModel)
        {
            //var page = inputModel.Page is not null ? int.Parse(inputModel.Page) : 0;

            //if(page > 1)
            //    request = new RestRequest($"/api/v1/assets?page={page}", Method.GET);
            //else
            var request = new RestRequest($"/api/v1/assets", Method.Get);
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
            var request = new RestRequest($"/api/v1/assets{id}", Method.Get);
            var client = await _assetService.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SingleAssetRoot>(request).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<List<AssetsPayload>> GetCahedAssets()
        {
            var result = await _assets.GetDocsAsync().ConfigureAwait(false);
            if (result == null) return new List<AssetsPayload>();
            return result;
        }

    }

    public class CachedAssetsService : ICachedAssetsService
    {
        public CachedAssetsService(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _assetsCollection = db.GetCollection<AssetsPayload>(ProvideCollectionName(typeof(AssetsPayload)));
        }

        private readonly IMongoCollection<AssetsPayload> _assetsCollection;

        public string CollectionName { get; set; }

        public async Task<List<AssetsPayload>> GetDocsAsync()
        {
            var cursor = await _assetsCollection.FindAsync(t => true).ConfigureAwait(false);
            var result = await cursor.ToListAsync().ConfigureAwait(false);
            return result;
        }

        private protected string ProvideCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                typeof(BsonCollectionAttribute),
                true)
            .FirstOrDefault())?.CollectionName;
        }
    }
}