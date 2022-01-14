using MongoDB.Driver;
using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class GeneralCowryService : IGeneralCowryService
    {
        private readonly ICacheBanksFromCowry _cowryCache;
        private readonly IHttpService _service;

        public GeneralCowryService(IHttpService service, ICacheBanksFromCowry cowryCache)
        {
            _cowryCache = cowryCache;
            _service = service;
        }
        public async Task<List<Bank>> GetBanks()
        {
            // fetch from db to avoid trip to cowry
            var cachedResponse = await _cowryCache.GetDocsAsync().ConfigureAwait(false);
            //if (cachedResponse is not null && cachedResponse.Single().Banks.Data.Any()) return cachedResponse.Single().Banks;
            // if db is empty then call cowry and populate
            return cachedResponse;

        }

        private async Task<RestResponse<BankResponse>> FetchBanksFromCowry(GetPaginatedResponseInputModel inputModel)
        {
            var request = new RestRequest("/api/v1/investments", Method.Post);
            request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
            request.AddParameter("page_size", inputModel.PageSize, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<BankResponse>(request)
                .ConfigureAwait(false);
            return result;
        }
    }

    public class CacheBanksFromCowry : ICacheBanksFromCowry
    {
        private readonly IMongoCollection<Bank> _bankCollection;

        public string CollectionName { get; set; }
        public CacheBanksFromCowry(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _bankCollection = db.GetCollection<Bank>(ProvideCollectionName(typeof(Bank)));
        }

        public async Task<List<Bank>> GetDocsAsync()
        {
            var cursor = await _bankCollection.FindAsync(t => true).ConfigureAwait(false);
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
