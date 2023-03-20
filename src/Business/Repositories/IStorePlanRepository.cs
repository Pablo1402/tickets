using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public interface IStorePlanRepository
    {
        Task<StorePlan> GetByName(string name);
        Task<StorePlan> GetByIdAsync(Guid id);
        Task<List<StorePlan>> GetAll();
        Task Create(StorePlan storePlan);
        Task Update(StorePlan storePlan);
        Task Delete(StorePlan storePlan);
    }
}
