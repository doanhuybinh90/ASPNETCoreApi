using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Administrators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AdministratorService : IAdministratorService
    {
        private IRepository<Administrator> _repository;

        public AdministratorService(IRepository<Administrator> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Administrator> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Administrator>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Administrator> Post(Administrator administrator)
        {
            return await _repository.InsertAsync(administrator);
        }

        public async Task<Administrator> Put(Administrator administrator)
        {
            return await _repository.UpdateAsync(administrator);
        }
    }
}
