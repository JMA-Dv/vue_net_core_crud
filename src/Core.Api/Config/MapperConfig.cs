using AutoMapper;
using Core.DTOs.Client;
using Core.Model;
using Service.Services.Common;
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
        }
    }
}
