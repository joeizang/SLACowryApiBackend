using MongoDB.Driver;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class MongodbPersistenceService<T> : IMongodbService<T> where T : BaseDomainModel
    {
        private readonly IMongoCollection<T> _genericCollection;
        public MongodbPersistenceService(IMongoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _genericCollection = db.GetCollection<T>(settings.CollectionName);
        }
        public async Task CreateOneAsync(T entity)
        {
            await _genericCollection.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public Task DeleteOneAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOneByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var cursor = await _genericCollection.FindAsync(t => t.Id == id).ConfigureAwait(false);
            return await cursor.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task UpdateOneAsync(string id, T entity)
        {
            await _genericCollection.ReplaceOneAsync(t => t.Id == id, entity).ConfigureAwait(false);
        }

        public async Task<List<T>> GetDocsAsync()
        {
            var cursor = await _genericCollection.FindAsync(g => true).ConfigureAwait(false);
            var result = await cursor.ToListAsync().ConfigureAwait(false);
            return result;
        }
    }
}
