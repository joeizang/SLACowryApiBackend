using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLACowryWise.Domain.DomainModels
{
    public class AccountCreated : BaseDomainModel
    {
        public AccountCreationResponse AccountCreationDto { get; set; }
    }

    public class AccountPortfolio : BaseDomainModel
    {
        public AccountPortfolioResponse AccountPortfolioDto { get; set; }
    }

    public class AccountBankUpdate : BaseDomainModel
    {
        public AccountBankUpdateResponse AccountBankUpdateDto { get; set; }
    }

    public class AccountIdentityUpdate : BaseDomainModel
    {
        public AccountIdentityResponse AccountIdentityDto { get; set; }
    }
}
