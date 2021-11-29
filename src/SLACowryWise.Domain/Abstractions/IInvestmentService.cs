using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Investments;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IInvestmentService
    {
        Task<SingleInvestmentResponseDto> CreateInvestment(CreateInvestmentInputModel inputModel);

        Task<InvestmentPaginatedDtoResponse> GetAllInvestments(InvestmentPaginatedResponseInput inputModel);

        Task<TransferFromWalletResponseDto> FundInvestment(WalletTransferInputModel inputModel);

        Task<InvestmentLiquidatedDto> LiquidateInvestment(string units, string investmentId);

        Task<SingleInvestmentResponseDto> GetSingleInvestment(string investmentId);
        
    }

    public interface ICreateInvestment : IMongodbService<CreateInvestment> { }

    public interface ILiquidateInvestment : IMongodbService<InvestmentLiquidation> { }

    public interface IInvestmentFunded : IMongodbService<InvestmentsFunded> { }
}