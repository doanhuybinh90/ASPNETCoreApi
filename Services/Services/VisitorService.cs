using AutoMapper;
using Domain.DTOs.Visitor;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.VIsitors;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VisitorService : IVisitorService
    {
        private IRepository<Visitor> _repository;
        private readonly IMapper _mapper;

        public VisitorService(IRepository<Visitor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<VisitorDtoGet> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<VisitorDtoGet>(entity);
        }

        public async Task<IEnumerable<VisitorDtoGet>> GetAll()
        {
            
            var listEntity =  await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<VisitorDtoGet>>(listEntity);
        }

        public async Task<InputCreateVisitor> Post(VisitorDtoPost visitor)
        {
            var model = _mapper.Map<VisitorModel>(visitor);
            var entity = _mapper.Map<Visitor>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<InputCreateVisitor>(result);
        }

        public async Task<InputUpdateVisitor> Put(VisitorDtoPut visitor)
        {
            var model = _mapper.Map<VisitorModel>(visitor);
            var entity = _mapper.Map<Visitor>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<InputUpdateVisitor>(result);
        }

        
    }
}
