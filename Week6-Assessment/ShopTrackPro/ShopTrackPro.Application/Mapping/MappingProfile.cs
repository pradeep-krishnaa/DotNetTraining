using AutoMapper;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, ProductResponseDTO>().ReverseMap();
            CreateMap<ProductRequestDTO, Product>();

            // User
            CreateMap<User, UserResponseDTO>().ReverseMap();
            CreateMap<UserRequestDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // handled in service

            // OrderItem
            CreateMap<OrderItem, OrderItemResponseDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));
            CreateMap<OrderItemRequestDTO, OrderItem>();

            // Order
            CreateMap<Order, OrderResponseDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username));
            CreateMap<OrderRequestDTO, Order>();
        }
    }
}
