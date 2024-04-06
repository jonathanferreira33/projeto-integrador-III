using PI.Domain.Entities;
using PI.Domain.Request;

namespace PI.Domain.Interfaces
{
    public interface IProductRepository : IRepositoryBase<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetByParameters(SearchRequest search);
    }
}
