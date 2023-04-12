using AutoMapper;
using OrderManagement1.Dto;
using OrderManagement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Products, ProductsDto>().ReverseMap();
            CreateMap<Products, GetProductsDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<Cart, GetCartDto>().ReverseMap();
            CreateMap<CartItems, CartItemsDto>().ReverseMap();
            CreateMap<CartItems, GetCartItemsDto>().ReverseMap();
            CreateMap<Orders, OrdersDto>().ReverseMap();            
            CreateMap<Orders, GetOrdersDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Payment, GetPaymentDto>().ReverseMap();
            CreateMap<Shipping, ShippingDto>().ReverseMap();
            CreateMap<Shipping, GetShippingDto>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();
            CreateMap<OrderItems, OrderItemsDto>().ReverseMap();
            CreateMap<OrderItems, GetOrderItemsDto>().ReverseMap();
        }
    }
}
