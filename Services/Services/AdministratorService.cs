using AutoMapper;
using Domain.DTOs.Administrator;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Administrators;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AdministratorService : IAdministratorService
    {
        private IRepository<Administrator> _repository;
        private readonly IMapper _mapper;

        public AdministratorService(IRepository<Administrator> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AdministratorDtoGet> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<AdministratorDtoGet>(entity);
        }

        public async Task<IEnumerable<AdministratorDtoGet>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<AdministratorDtoGet>>(listEntity);
        }

        public async Task<InputCreateAdmin> Post(AdminDtoPost admin)
        {
            var model = _mapper.Map<AdministratorModel>(admin);
            var entity = _mapper.Map<Administrator>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<InputCreateAdmin>(result);
        }

        public async Task<InputUpdateAdmin> Put(AdminDtoPut admin)
        {
            var model = _mapper.Map<AdministratorModel>(admin);
            var entity = _mapper.Map<Administrator>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<InputUpdateAdmin>(result);
        }

        
    }
}
