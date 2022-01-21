using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Wallets;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.DomainModels
{
    [BsonCollection("CreatedWallets")]
    public class CreateWallet : BaseDomainModel
    {
        public RestResponse<CreateWalletResponseDto> CreateWalletResponseDto { get; set; }
        public CreateWalletInputModel Response { get; internal set; }
    }

    [BsonCollection("FundsWalletTransfer")]
    public class FundsWalletTransfer : BaseDomainModel
    {
        public RestResponse<WalletTransferDtoRoot> TransferFundsFromWallet { get; set; }
        public WalletTransferInputModel Response { get; internal set; }
    }
}
