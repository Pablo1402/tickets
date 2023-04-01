using Business.Entities;
using Business.Interfaces.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TicketupContext _context;

        public UserRepository(TicketupContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllByStoreAsync(Guid storeId)
        {
            return await _context.Users
                .Where(x => x.StoreId == storeId)
                .Include(x => x.UserType)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .Include(x => x.UserType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _context.Users.Include(x => x.UserType).Include(x => x.Store).FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
