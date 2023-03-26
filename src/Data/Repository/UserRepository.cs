using Business.Entities;
using Business.Repositories;
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
        public async Task<User> GetByLogin(string login)
        {
            return await _context.Users.Include(x => x.UserType).FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
