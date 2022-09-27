using AutoMapper;
using Core.DTOs.Client;
using Core.DTOs.Identity;
using Core.DTOs.Orders;
using Core.DTOs.Products;
using Core.Model;
using Core.Model.Identity;
using Core.Model.Orders;
using Core.Model.Products;
using Microsoft.AspNetCore.Identity;
using Service.Services.Common.Pagination;
using System.Linq;

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


            //CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(x => x.FullName,
                opt => opt.MapFrom(src => src.LastName + ", " + src.FirstName))
                .ForMember(x => x.Roles, p => p.MapFrom(src => src.UserRoles.Select(x => x.Role.Name).ToList()));
            CreateMap<PaginatedList<ApplicationUser>, PaginatedList<ApplicationUserDto>>();

            CreateMap<IdentityUser, ApplicationUserDto>().ForMember(
                to=> to.FullName,
                from=> from.MapFrom(src=> src.UserName)).ForMember(to=> to.Roles, from=> from.MapFrom(src=> src.Rol));
            CreateMap<PaginatedList<IdentityUser>, PaginatedList<ApplicationUserDto>>();

            //CreateMap<ApplicationUserRole, ApplicationUserRoleDto>();
            //CreateMap<ApplicationRole, ApplicationRoleDto>();





        }
    }
}
