using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IGeneralCowryService
    {
        Task<List<Bank>> GetBanks();
    }

    public interface ICacheBankFromCowry : IMongodbService<CowryBanks> { }
}
