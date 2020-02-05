using Domain.DTOs.Visitor;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.VIsitors
{
    public interface IVisitorService
    {
        Task<VisitorDtoGet> Get(Guid id);
        Task<IEnumerable<VisitorDtoGet>> GetAll();
        Task<InputCreateVisitor> Post(VisitorDtoPost visitor);
        Task<InputUpdateVisitor> Put(VisitorDtoPut visitor);
        Task<bool> Delete(Guid id);
    }
}
