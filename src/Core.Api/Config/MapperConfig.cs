using AutoMapper;
using Core.DTOs.Client;
using Core.DTOs.Orders;
using Core.DTOs.Products;
using Core.DTOs.User;
using Core.Model;
using Core.Model.Identity;
using Core.Model.Orders;
using Core.Model.Products;
using Service.Services.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<PaginatedList<Client>,PaginatedList<ClientDto>>();
            
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail,OrderDetailDto>();
            CreateMap<PaginatedList<Order>,PaginatedList<OrderDto>>();
            
            
            CreateMap<OrderCreateDto, Order>();

            CreateMap<OrderDetailCreateDto, OrderDetail>();
            

            CreateMap<PaginatedList<Product>,PaginatedList<ProductDto>>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
