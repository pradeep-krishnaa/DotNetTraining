using AutoMapper;
using Bank.Core.DTOs;
using Bank.Core.Entities;
using Bank.Core.Interfaces;
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
        private readonly IAccountRepository _accountRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepo, IMapper mapper, IAccountRepository accountRepository)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _accountRepo = accountRepository;
        }

        public async Task<List<CustomerResponseDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepo.GetAllAsync();
            return _mapper.Map<List<CustomerResponseDTO>>(customers);
        }

        public async Task<CustomerResponseDTO?> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepo.GetByIdAsync(id);
            return _mapper.Map<CustomerResponseDTO?>(customer);
        }

        public async Task AddCustomerAsync(CustomerRequestDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepo.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, CustomerRequestDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            customer.CustomerId = id;
            await _customerRepo.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepo.DeleteAsync(id);
        }
    }
}
