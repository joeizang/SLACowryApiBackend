using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Wallets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IWalletService
    {
        Task<WalletPaginatedDtoRoot> GetAllWallets(GetPaginatedResponseInputModel query);
        Task<CreateWalletResponseDto> CreateWallet(CreateWalletInputModel inputModel);
        Task<SingleWalletResponse> GetAWallet(string walletId);
        Task<WalletTransferDtoRoot> TransferFundsFromWallet(WalletTransferInputModel inputModel);

        Task<List<string>> ReturnWalletIdsByAccountId(string accountId);
    }

    public interface ICreateWallet : IMongodbService<CreateWallet> { }

    public interface IFundsWalletTransfer : IMongodbService<FundsWalletTransfer> { }
}