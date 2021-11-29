using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Wallets;
using SLACowryWise.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.DomainModels
{
    [BsonCollection("CreatedWallets")]
    public class CreateWallet : BaseDomainModel
    {
        public CreateWalletResponseDto CreateWalletResponseDto { get; set; }
    }

    [BsonCollection("FundsWalletTransfer")]
    public class FundsWalletTransfer : BaseDomainModel
    {
        public WalletTransferDtoRoot TransferFundsFromWallet { get; set; }
    }
}
