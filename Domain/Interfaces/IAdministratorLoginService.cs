using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAdministratorLoginService
    {
        Task<object> FindByLogin(Administrator administrator);
    }
}
