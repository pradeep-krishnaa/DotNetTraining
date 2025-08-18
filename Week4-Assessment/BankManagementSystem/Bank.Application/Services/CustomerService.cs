using AutoMapper;
using Bank.Core.DTOs;
using Bank.Core.Entities;
using Bank.Core.Interfaces;
using Bank.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<List<CustomerResponseDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepo.GetAllAsync();
            return customers.Select(c => new CustomerResponseDTO
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName
            }).ToList();
        }

        public async Task<CustomerResponseDTO?> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepo.GetByIdAsync(id);
            if (customer == null) return null;

            return new CustomerResponseDTO
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName
            };
        }

        public async Task AddCustomerAsync(CustomerRequestDTO dto)
        {
            var customer = new Customer
            {
                CustomerName = dto.CustomerName
            };

            await _customerRepo.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, CustomerRequestDTO dto)
        {
            var existing = await _customerRepo.GetByIdAsync(id);
            if (existing == null) throw new Exception("Customer not found");

            existing.CustomerName = dto.CustomerName;

            await _customerRepo.UpdateAsync(existing);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepo.DeleteAsync(id);
        }
    }
}
