using CRUD.Domain.Dto.Client;
using CRUD.Domain.Models;
using System;

namespace CRUD.Domain.Interface.Repositories
{
    public interface IClientRepository
    {
        public Task<Client> Create(Client client);
        public Task<Client> GetById(Guid id);
        public Task<List<Client>> GetAll();
        public Task<Client> Update(Client clientIn);
        public Task<Client> Delete(Guid id);
    }
}
