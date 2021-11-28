using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Savings;

namespace SLACowryWise.Domain.DomainModels
{
    public class SingleSaving : BaseDomainModel
    {
        public SingleSavingsResponse SingleSavingsResponse { get; set; }
    }

    public class CreateSavings : BaseDomainModel
    {
        public CreateSavingsResponse CreateSavingsResponse { get; set; }
    }

    public class FundSavings : BaseDomainModel
    {
        public FundSavingsDtoResponse FundSavingsDtoResponse { get; set; }
    }
}