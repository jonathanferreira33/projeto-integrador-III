using PI.Domain.Entities;
using PI.Domain.Request;

namespace PI.Domain.Interfaces.Services
{
    public interface IProductService : IBaseService<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> SearchAsync(SearchRequest search);

        Task<ProductEntity> QuantityChange(ProductEntity product, int amount);
    }
}