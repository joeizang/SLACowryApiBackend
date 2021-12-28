using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IGeneralCowryService
    {
        Task<BankResponse> GetBanks(GetPaginatedResponseInputModel inputModel);
    }

    public interface ICacheBankFromCowry : IMongodbService<CowryBanks> { }
}
