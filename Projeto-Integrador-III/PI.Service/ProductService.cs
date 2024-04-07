using PI.Domain.Entities;
using PI.Domain.Interfaces;
using PI.Domain.Interfaces.Services;
using PI.Domain.Request;

namespace PI.Service
{
    public class ProductService : IBaseService<ProductEntity>, IProductService
    {
        private IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ProductEntity> Get(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductEntity> Post(ProductEntity productRequest)
        {
            var newProduct = await _repository.CreateAsync(productRequest);
            return newProduct;
        }

        public async Task<ProductEntity> Put(ProductEntity product)
        {
            return await _repository.UpdateAsync(product);
        }

        public async Task<ProductEntity> QuantityChange(ProductEntity product, int amount)
        {
            product.Amount += amount;
            product.UpdateAt = DateTime.Now;
            return await _repository.UpdateAsync(product);
        }

        public async Task<IEnumerable<ProductEntity>> SearchAsync(SearchRequest search)
        {
            return await _repository.GetByParameters(search);
        }
    }
}
