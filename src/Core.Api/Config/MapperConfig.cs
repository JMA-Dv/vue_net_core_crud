using AutoMapper;
using Core.DTOs.Client;
using Core.DTOs.Orders;
using Core.DTOs.Products;
using Core.Model;
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
            
            CreateMap<PaginatedList<Order>,PaginatedList<OrderDto>>();
            CreateMap<Order, OrderDto>();

            CreateMap<OrderDetail, OrderDetailDto>();

            CreateMap<PaginatedList<Product>,PaginatedList<ProductDto>>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductDto>();


        }
    }
}
