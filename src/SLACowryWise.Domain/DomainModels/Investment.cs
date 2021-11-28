using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Investments;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLACowryWise.Domain.DomainModels
{
    public class SingleInvestment : BaseDomainModel
    {
        public SingleInvestmentResponseDto SingleInvestmentResponseDto { get; set; }
    }

    public class InvestmentLiquidation : BaseDomainModel
    {
        public InvestmentLiquidatedDto InvestmentLiquidatedDto { get; set; }
    }


}
