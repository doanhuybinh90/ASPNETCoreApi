using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.VIsitors
{
    public interface IVisitorService
    {
        Task<Visitor> Get(Guid id);
        Task<IEnumerable<Visitor>> GetAll();
        Task<Visitor> Post(Visitor visitor);
        Task<Visitor> Put(Visitor visitor);
        Task<bool> Delete(Guid id);
    }
}
