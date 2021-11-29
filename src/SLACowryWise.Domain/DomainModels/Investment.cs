using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Investments;
using SLACowryWise.Domain.DTOs.Wallets;
using SLACowryWise.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLACowryWise.Domain.DomainModels
{
    [BsonCollection("InvestmentsCreated")]
    public class CreateInvestment : BaseDomainModel
    {
        public SingleInvestmentResponseDto SingleInvestmentResponseDto { get; set; }
    }

    [BsonCollection("InvestmentsLiquidated")]
    public class InvestmentLiquidation : BaseDomainModel
    {
        public InvestmentLiquidatedDto InvestmentLiquidatedDto { get; set; }
    }

    [BsonCollection("InvestmentsFunded")]
    public class InvestmentsFunded : BaseDomainModel
    {
        public TransferFromWalletResponseDto FundedInvestmentDto { get; set; }
    }



}
