using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IUserTypeService
    {
        Task<UserType> GetByIdAsync(Guid id);
        Task<List<UserType>> GetAllAsync();
        Task<List<UserType>> GetDropdownAsync(List<string> names);
        Task CreateAsync(UserType userType);
        Task UpdateAsync(UserType userType);
        Task DeleteAsync(UserType userType);
    }
}
