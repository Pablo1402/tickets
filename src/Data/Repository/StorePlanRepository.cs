using Business.Entities;
using Business.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class StorePlanRepository : IStorePlanRepository
    {
        private readonly TicketupContext _context;

        public StorePlanRepository(TicketupContext context)
        {
            _context = context;
        }

        public async Task Create(StorePlan storePlan)
        {
            await _context.StorePlans.AddAsync(storePlan);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StorePlan>> GetAll()
        {
            return await _context.StorePlans.Include(x => x.Stores).ToListAsync();
        }

        public async Task<StorePlan> GetByName(string name)
        {
            return await _context
                .StorePlans
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<StorePlan> GetByIdAsync(Guid id)
        {
            return await _context.StorePlans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(StorePlan storePlan)
        {
            _context.StorePlans.Update(storePlan);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(StorePlan storePlan)
        {
            _context.StorePlans.Remove(storePlan);
            await _context.SaveChangesAsync();
        }
    }
}
