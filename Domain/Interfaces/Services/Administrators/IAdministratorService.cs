using Domain.DTOs.Administrator;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Administrators
{
    public interface IAdministratorService
    {
        Task<AdministratorDtoGet> Get(Guid id);
        Task<IEnumerable<AdministratorDtoGet>> GetAll();
        Task<InputCreateAdmin> Post(AdminDtoPost administrator);
        Task<InputUpdateAdmin> Put(AdminDtoPut administrator);
        Task<bool> Delete(Guid id);
    }
}
