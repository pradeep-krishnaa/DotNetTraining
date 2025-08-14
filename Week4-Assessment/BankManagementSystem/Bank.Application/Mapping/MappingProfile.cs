using AutoMapper;
using Bank.Core.DTOs;
using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerRequestDTO>().ReverseMap();
            CreateMap<Customer, CustomerResponseDTO>();
            CreateMap<Account, AccountRequestDTO>().ReverseMap();
            CreateMap<Account, AccountResponseDTO>();
            CreateMap<Transaction, TransactionRequestDTO>().ReverseMap();
            CreateMap<Transaction, TransactionResponseDTO>();
        }
    }
}
