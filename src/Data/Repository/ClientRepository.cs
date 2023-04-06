using Business.Entities;
using Business.Interfaces.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly TicketupContext _context;

        public ClientRepository(TicketupContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllByStoreAsync(Guid storeId)
        {
            return await _context.Clients
              .Where(x => x.StoreId == storeId)
              .AsNoTracking()
              .ToListAsync();
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _context.Clients
                .Include(x => x.ClientCampains)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
