using Microsoft.EntityFrameworkCore;
using SLACowryWise.Domain.DomainModels.WebhookPayloads;

namespace SLACowryWise.Domain.Data
{
    public class SlaCowryWiseContext : DbContext
    {
        public SlaCowryWiseContext(DbContextOptions<SlaCowryWiseContext> options) : base(options)
        {
            
        }
    }
}