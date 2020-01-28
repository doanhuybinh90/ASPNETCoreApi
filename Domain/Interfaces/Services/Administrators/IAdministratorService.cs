using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Administrators
{
    public interface IAdministratorService
    {
        Task<Administrator> Get(Guid id);
        Task<IEnumerable<Administrator>> GetAll();
        Task<Administrator> Post(Administrator administrator);
        Task<Administrator> Put(Administrator administrator);
        Task<bool> Delete(Guid id);
    }
}
