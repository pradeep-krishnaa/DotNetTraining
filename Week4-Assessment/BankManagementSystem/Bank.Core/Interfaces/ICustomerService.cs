using Bank.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerResponseDTO>> GetAllCustomersAsync();
        Task<CustomerResponseDTO?> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerRequestDTO customer);
        Task UpdateCustomerAsync(int id, CustomerRequestDTO customer);
        Task DeleteCustomerAsync(int id);
    }
}
