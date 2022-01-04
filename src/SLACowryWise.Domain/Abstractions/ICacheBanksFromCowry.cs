using SLACowryWise.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface ICacheBanksFromCowry
    {
        string CollectionName { get; set; }

        Task<List<Bank>> GetDocsAsync();
    }
}
