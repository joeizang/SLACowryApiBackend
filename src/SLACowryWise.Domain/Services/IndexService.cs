﻿using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Indexes;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class IndexService : IIndex
    {
        private readonly IHttpService _service;

        public IndexService(IHttpService service)
        {
            _service = service;
        }
        public async Task<CustomIndexResponse> CreateCustomIndex(CustomIndexInputModel inputModel)
        {

            var request = new RestRequest($"/api/v1/indexes", Method.Post);
            request.AddParameter("name", inputModel.Name, ParameterType.GetOrPost);
            request.AddParameter("description", inputModel.Description, ParameterType.GetOrPost);
            request.AddParameter("allocations", inputModel.Allocations, ParameterType.GetOrPost);
            request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<CustomIndexResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<IndexAssetsResponse> GetIndexAssets(string indexId)
        {
            var request = new RestRequest($"/api/v1/indexes/{indexId}/assets", Method.Get);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<IndexAssetsResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<IndexPaginatedResponse> GetIndexes(GetPaginatedResponseInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/indexes", Method.Get);
            request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
            request.AddParameter("page_size", inputModel.PageSize, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<IndexPaginatedResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SingleIndexResponse> GetSingleIndex(string indexId)
        {
            var request = new RestRequest($"/api/v1/indexes/{indexId}", Method.Get);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SingleIndexResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<UpdateCustomIndexResponse> UpdateCustomIndex(UpdateCustomIndexInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/indexes", Method.Get);
            request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
            request.AddParameter("allocations", inputModel.Allocations, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<UpdateCustomIndexResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }
    }
}
