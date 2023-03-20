using Business.Entities;
using Business.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly TicketupContext _context;

        public StoreRepository(TicketupContext context)
        {
            _context = context;
        }

        public async Task Create(Store store)
        {
            await _context.AddAsync(store);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Store store)
        {
            _context.Remove(store);
            await _context.SaveChangesAsync();
        }

        public async Task<List <Store>> GetAllActives()
        {
            var stores = await _context.Stores.Include(x => x.StorePlan).Include(x => x.Campains)
                .AsNoTracking()
                .ToListAsync();
            return stores;
        }

        public async Task<Store> GetById(Guid id)
        {
            return await _context
                 .Stores
                 .AsNoTracking()
                 .Include(s => s.StorePlan)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Store store)
        {
            _context.Update(store);
            await _context.SaveChangesAsync();
        }
    }
}
