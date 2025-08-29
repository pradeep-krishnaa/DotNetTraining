using AutoMapper;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductResponseDTO>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }

        public async Task<ProductResponseDTO?> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductResponseDTO?>(product);
        }

        public async Task AddProductAsync(ProductRequestDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repository.AddAsync(product);
        }

        public async Task UpdateProductAsync(int id, ProductRequestDTO dto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return;

            _mapper.Map(dto, product);
            await _repository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
