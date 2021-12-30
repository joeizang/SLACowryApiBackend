using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class GeneralCowryService : IGeneralCowryService
    {
        private readonly ICacheBankFromCowry _cowryCache;
        private readonly IHttpService _service;

        public GeneralCowryService(IHttpService service, ICacheBankFromCowry cowryCache)
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
            return cachedResponse.Single().Banks.Data;

        }

        private async Task<IRestResponse<BankResponse>> FetchBanksFromCowry(GetPaginatedResponseInputModel inputModel)
        {
            var request = new RestRequest("/api/v1/investments", Method.POST);
            request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
            request.AddParameter("page_size", inputModel.PageSize, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<BankResponse>(request)
                .ConfigureAwait(false);
            return result;
        }
    }

    public class CacheBanksFromCowry : MongodbPersistenceService<CowryBanks>, ICacheBankFromCowry
    {
        public CacheBanksFromCowry(IMongoDatabaseSettings settings) : base(settings)
        {

        }
    }
}
