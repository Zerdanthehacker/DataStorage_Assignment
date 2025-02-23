using Data.Entities;
using Data.Repositories;

namespace Data.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // CREATE
        public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
        {
            return await _productRepository.CreateAsync(product);
        }

        // READ
        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        
        public async Task<ProductEntity?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        // UPDATE 
        public async Task<ProductEntity?> UpdateProductAsync(ProductEntity updatedProduct)
        {
            return await _productRepository.UpdateAsync(updatedProduct);
        }

        // DELETE
        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
