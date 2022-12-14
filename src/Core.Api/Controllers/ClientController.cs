using Core.DTOs.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Clients;
using Service.Services.Common.Helpers;
using Service.Services.Common.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize(Roles =RoleHelper.Admin + "," + RoleHelper.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _client;

        public ClientController(IClientService client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ClientDto>>> GetAll(int page, int take = 20) => await _client.GetAllPaginated(page, take);
        

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetClientById(int id)
            => await _client.GetById(id);


        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveClient(int id)
        {
             await _client.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ClientCreateDto client)
        {
            var result = await _client.Create(client);
            return CreatedAtAction
                (
                "GetClientById",
                new {Id= result.ClientId},
                result
                );
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClient(ClientUpdateDto client, int id)
        {
            await _client.Update(client,id);
            return Ok();
        }
    }
}
