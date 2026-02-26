using CRUD.Domain.Interface.Repositories;
using CRUD.Domain.Models;
using CRUD.Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infra.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _clientRepository;
        public ClientRepository(DataContext clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Client> Create(Client client)
        {
            var clientDb =  _clientRepository.Clients
                .SingleOrDefault(u => u.Name == client.Name);

            if (clientDb is not null)
                throw new Exception($"clientName {client.Name} already exist!");

            _clientRepository.Clients.Add(client);
            await _clientRepository.SaveChangesAsync();

            return client;
        }

        public async Task<Client> Delete(Guid id)
        {
            var clientDb = await _clientRepository.Clients
                .SingleOrDefaultAsync(u => u.Id == id);

            if (clientDb is null)
                throw new Exception($"client {id} not found");

            _clientRepository.Clients.Remove(clientDb);
            await _clientRepository.SaveChangesAsync();
            return clientDb;
        }

        public async Task<List<Client>> GetAll()
        {
           var getAll = await _clientRepository.Clients.ToListAsync();
           return getAll;
        }

        public async Task<Client> GetById(Guid id)
        {
            var getId = await _clientRepository.Clients
                .SingleOrDefaultAsync(u => u.Id == id);

            if (getId is null)
                throw new Exception($"client {id} not found");

            return getId;
        }

        public async Task<Client> Update(Client clientIn)
        {
            var update = await _clientRepository.Clients
                .SingleOrDefaultAsync(u => u.Id == clientIn.Id);

            if (update is null)
                throw new Exception($"client {clientIn.Id} not found");
            
            _clientRepository.Entry(update).CurrentValues.SetValues(clientIn);
            await _clientRepository.SaveChangesAsync();
            return update;
        }
    }
}
