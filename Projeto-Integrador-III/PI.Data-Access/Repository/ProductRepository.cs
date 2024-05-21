using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PI.Data_Access.Context;
using PI.Domain.Entities;
using PI.Domain.Interfaces;
using PI.Domain.Request;

namespace PI.Data_Access.Repository
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        private DbSet<ProductEntity> _dataset;
        private readonly MySQLContext _context;
        private readonly IMemoryCache _memoryCache;

        public ProductRepository(MySQLContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _memoryCache = memoryCache;
            _context = context;
            _dataset = context.Set<ProductEntity>();
        }

        public async Task<IEnumerable<ProductEntity>> GetByParameters(SearchRequest search)
        {
            return await _dataset
                .Where(x => x.Name.Equals(search.Name))
                .Where(x => x.Category.Equals(search.Category))
                .Where(x => x.Description.Equals(search.Description))
                .ToListAsync();


            //return await _dataset.AsQueryable().Join(search,
            //    )

        }
    }
}
