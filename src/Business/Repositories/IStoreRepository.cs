using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public interface IStoreRepository
    {
        Task Create(Store store);
        Task Update(Store store);
        Task Delete(Store store);

        Task<Store> GetById(Guid id);

        Task<List<Store>> GetAllActives();

    }
}
