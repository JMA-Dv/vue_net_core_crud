using AutoMapper;
using Core.DTOs.Client;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Service.Services.Common;
using Service.Services.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Clients
{
    public interface IClientService: IRepository<Client,ClientCreateDto,ClientDto>
    {
        public Task<PaginatedList<ClientDto>> GetAllPaginated(int page, int take = 20);
    }
    public class ClientService : IClientService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClientService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Client> Create(ClientCreateDto model)
        {
            var client = new Client()
            {
                Name = model.Name
            };
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task Delete(int id)
        {
             _context.Clients.Remove(
                new Client()
                {
                    ClientId = id
                });

            await _context.SaveChangesAsync();

        }

        public async Task<PaginatedList<ClientDto>> GetAllPaginated(int page, int take)
        {
            return _mapper.Map<PaginatedList<ClientDto>>(
                await _context.Clients.OrderByDescending(x => x.ClientId)
                .AsQueryable()
                .PagedAsync(page, take));
        }

        public async Task<ClientDto> GetById(int id)
        {
            var result =  await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            return _mapper.Map<ClientDto>(result);
        }


        public async Task<ClientDto> Update(ClientCreateDto model, int id)
        {
            var client = await _context.Clients.FindAsync(id);

            client.Name = model.Name;

            await _context.SaveChangesAsync();
            return _mapper.Map<ClientDto>(client);
        }
    }
}

