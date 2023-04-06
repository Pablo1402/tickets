using Business.Entities;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Client client)
        {
            await _repository.CreateAsync(client);
        }

        public async Task DeleteAsync(Client client)
        {
            await _repository.DeleteAsync(client);
        }

        public async Task<List<Client>> GetAllByStoreAsync(Guid storeId)
        {
            return await _repository.GetAllByStoreAsync(storeId);
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Client client)
        {
            await _repository.UpdateAsync(client);
        }
    }
}
