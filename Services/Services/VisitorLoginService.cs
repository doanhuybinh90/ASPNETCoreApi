using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VisitorLoginService : IVisitorLoginService
    {
        private IVisitorRepository _repository;

        public VisitorLoginService(IVisitorRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(Visitor visitor)
        {
            if (visitor != null && !string.IsNullOrWhiteSpace(visitor.Email))
            {
                return await _repository.FindByLogin(visitor.Email);

            }
            else
            {
                return null;
            }

        }
    }
}
