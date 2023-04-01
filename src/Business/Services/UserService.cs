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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repositorio;

        public UserService(IUserRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task CreateAsync(User user)
        {
            await _repositorio.CreateAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await _repositorio.DeleteAsync(user);
        }

        public async Task<List<User>> GetAllByStoreAsync(Guid storeId)
        {
            return await _repositorio.GetAllByStoreAsync(storeId);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _repositorio.GetByIdAsync(id);
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _repositorio.GetByLogin(login);
        }

        public async Task UpdateAsync(User user)
        {
            await _repositorio.UpdateAsync(user);
        }
    }
}
