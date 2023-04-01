using Business.Entities;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;

namespace Business.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _repository;

        public UserTypeService(IUserTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(UserType userType)
        {
            await _repository.CreateAsync(userType);
        }

        public async Task DeleteAsync(UserType userType)
        {
            await _repository.DeleteAsync(userType);
        }

        public async Task<List<UserType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserType> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UserType userType)
        {
            await _repository.UpdateAsync(userType);
        }
    }
}
