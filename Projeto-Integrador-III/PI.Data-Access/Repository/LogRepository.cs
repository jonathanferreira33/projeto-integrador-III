using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PI.Data_Access.Context;
using PI.Domain.Entities;
using PI.Domain.Interfaces;
using PI.Domain.Request;
using System.Data;

namespace PI.Data_Access.Repository
{
    public class LogRepository : BaseRepository<LogEntity>, ILogRepository
    {
        private DbSet<LogEntity> _dataset;
        private readonly MySQLContext _context;
        private readonly IMemoryCache _memoryCache;

        public LogRepository(MySQLContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _memoryCache = memoryCache;
            _context = context;
            _dataset = context.Set<LogEntity>();
        }

        public async Task<IEnumerable<LogEntity>> GetByParameters(SearchRequest search)
        {
            return await _dataset
                .Where(x => x.UserName.Equals(search.Name))
                .Where(x => x.DateRecord.Equals(search.DateRecord))
                .ToListAsync();
        }
    }
}
