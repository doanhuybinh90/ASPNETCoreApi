using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IVisitorRepository : IRepository<Visitor>
    {
        Task<Visitor> FindByLogin(string email);
    }
}
