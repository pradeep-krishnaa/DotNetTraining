using ShopTrackPro.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponseDTO>> GetAllProductsAsync();
        Task<ProductResponseDTO?> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductRequestDTO Product);
        Task UpdateProductAsync(int id, ProductRequestDTO Product);
        Task DeleteProductAsync(int id);
    }
}
