using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Accounts;
using SLACowryWise.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLACowryWise.Domain.DomainModels
{
    [BsonCollection("AccountsCreated")]
    public class AccountCreated : BaseDomainModel
    {
        public AccountCreationResponse AccountCreationDto { get; set; }
    }

    [BsonCollection("AccountsPortfolios")]
    public class AccountPortfolio : BaseDomainModel
    {
        public AccountPortfolioResponse AccountPortfolioDto { get; set; }
    }

    [BsonCollection("AccountsBankUpdate")]
    public class AccountBankUpdate : BaseDomainModel
    {
        public AccountBankUpdateResponse AccountBankUpdateDto { get; set; }
    }

    [BsonCollection("AccountsIdentityUpate")]
    public class AccountIdentityUpdate : BaseDomainModel
    {
        public AccountIdentityResponse AccountIdentityDto { get; set; }
    }
}
