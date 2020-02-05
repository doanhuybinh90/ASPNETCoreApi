using AutoMapper;
using Domain.DTOs.Administrator;
using Domain.DTOs.Bookings;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Bookings;
using Domain.Models;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _repository;
        private readonly IMapper _mapper;
        private IAdministratorRepository _repositoryAdmin;
        private IVisitorRepository _visitorRepository;
        

        public BookingService(IBookingRepository repository, IMapper mapper, IAdministratorRepository repositoryAdmin, IVisitorRepository visitorRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryAdmin = repositoryAdmin;
            _visitorRepository = visitorRepository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<BookingDtoGet> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<BookingDtoGet>(entity);
        }

        public async Task<IEnumerable<BookingDtoGet>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<BookingDtoGet>>(listEntity);
        }

        public async Task<InputCreateBooking> Post(BookingDtoPost booking)
        {
            var visitor = await _visitorRepository.SelectAsync(booking.VisitorId);
            var administrator = await _repositoryAdmin.SelectAsync(booking.AdminId);
            var model = _mapper.Map<BookingModel>(booking);
            var entity = _mapper.Map<Booking>(model);
            entity.Administrator = administrator;
            entity.Visitor = visitor;
            var result = await _repository.InsertAsync(entity);

            var teste = _mapper.Map<InputCreateBooking>(result);

            return teste;
        }

        public async Task<InputUpdateBooking> Put(BookingDtoPut booking)
        {
           
            var model = _mapper.Map<BookingModel>(booking);
            var entity = _mapper.Map<Booking>(model);
            var result = await _repository.UpdateAsync(entity);
            

            return _mapper.Map<InputUpdateBooking>(result);
        }
    }
}
