using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IVisitorLoginService
    {
        Task<object> FindByLogin(Visitor visitor);

        
    }
}
