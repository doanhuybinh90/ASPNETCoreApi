using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAdministratorRepository : IRepository<Administrator>
    {
        Task<Administrator> FindByLogin(string email);
    }
}
