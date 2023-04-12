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
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly TicketupContext _context;

        public UserTypeRepository(TicketupContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserType userType)
        {
            await _context.UserTypes.AddAsync(userType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserType userType)
        {
            _context.UserTypes.Remove(userType);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserType>> GetAllAsync()
        {
            return await _context.UserTypes.ToListAsync();
        }

        public async Task<UserType> GetByIdAsync(Guid id)
        {
            return await _context.UserTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserType>> GetDropdownAsync(List<string> names)
        {
            return await _context.UserTypes.Where(x => names.Contains(x.Name) ).ToListAsync();
        }

        public async Task UpdateAsync(UserType userType)
        {
            _context.UserTypes.Update(userType);
            await _context.SaveChangesAsync();
        }
    }
}
