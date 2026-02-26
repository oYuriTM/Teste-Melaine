using CRUD.Domain.Dto.Client;
using CRUD.Domain.Interface.Services;
using CRUD.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientRegisterDto client) => 
            Ok(await _clientService.Create(client));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _clientService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _clientService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) => Ok(await _clientService.GetById(id));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClientUpdateDto clientIn)
        {
            await _clientService.Update(clientIn);
            return NoContent();
        }
    }
}
