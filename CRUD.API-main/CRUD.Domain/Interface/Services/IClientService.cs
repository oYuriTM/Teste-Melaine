using CRUD.Domain.Dto.Client;
using CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Interface.Services
{
    public interface IClientService
    {
        public Task<ClientResponseDto> Create(ClientRegisterDto client);
        public Task<ClientResponseDto> GetById(Guid id);
        public Task<List<ClientResponseDto>> GetAll();
        public Task<ClientResponseDto> Update(ClientUpdateDto clientIn);
        public Task<ClientResponseDto> Delete(Guid id);
    }
}
