using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.DomainModels
{
    [BsonCollection("Settlements")]
    public class WithdrawToUserBank : BaseDomainModel
    {
        public RestResponse<SettlementResponseDto> WithdrawalResponse { get; set; }
        public SettlementInputModel Request { get; set; }
    }
}
