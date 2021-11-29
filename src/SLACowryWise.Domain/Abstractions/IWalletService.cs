using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IWalletService
    {
        Task<WalletPaginatedDtoRoot> GetAllWallets(string page = "1", string pageSize = "10");
        Task<CreateWalletResponseDto> CreateWallet(CreateWalletInputModel inputModel);
        Task<SingleWalletResponse> GetAWallet(string walletId);
        Task<WalletTransferDtoRoot> TransferFundsFromWallet(WalletTransferInputModel inputModel);
    }

    public interface ICreateWallet : IMongodbService<CreateWallet> { }

    public interface IFundsWalletTransfer : IMongodbService<FundsWalletTransfer> { }
}