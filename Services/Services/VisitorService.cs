using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.VIsitors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VisitorService : IVisitorService
    {
        private IRepository<Visitor> _repository;

        public VisitorService(IRepository<Visitor> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Visitor> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Visitor>> GetAll()
        {
            
            return await _repository.SelectAsync();
        }

        public async Task<Visitor> Post(Visitor visitor)
        {
            return await _repository.InsertAsync(visitor);
        }

        public async Task<Visitor> Put(Visitor visitor)
        {
            return await _repository.UpdateAsync(visitor);
        }
    }
}
