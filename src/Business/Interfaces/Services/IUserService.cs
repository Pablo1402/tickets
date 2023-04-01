using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetByLogin(string login);
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetAllByStoreAsync(Guid storeId);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
