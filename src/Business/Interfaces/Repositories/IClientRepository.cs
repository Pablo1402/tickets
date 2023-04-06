using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(Guid id);
        Task<List<Client>> GetAllByStoreAsync(Guid storeId);
        Task CreateAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(Client client);
    }
}
