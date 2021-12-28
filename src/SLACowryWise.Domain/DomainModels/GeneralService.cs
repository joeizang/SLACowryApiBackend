using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.DomainModels
{
    [BsonCollection("CowryBanks")]
    public class CowryBanks : BaseDomainModel
    {
        public BankResponse Banks { get; set; }
    }
}
