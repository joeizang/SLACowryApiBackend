using SLACowryWise.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IMongodbService<T> where T : BaseDomainModel
    {
        Task<List<T>> GetDocsAsync();

        Task<T> GetByIdAsync(string id);

        Task CreateOneAsync(T entity);

        Task UpdateOneAsync(string id, T entity);

        Task DeleteOneAsync(T entity);

        Task DeleteOneByIdAsync(string id);
    }

    public interface IAccountPortfolio : IMongodbService<AccountPortfolio> { }

    public interface IAccountCreated : IMongodbService<AccountCreated> { }

    public interface IAccountBankDetailsUpdated : IMongodbService<AccountBankUpdate> { }
}
