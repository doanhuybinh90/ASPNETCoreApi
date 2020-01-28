using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Bookings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _repository;
        

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Booking> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Booking> Post(Booking booking)
        {
            return await _repository.InsertAsync(booking);
        }

        public async Task<Booking> Put(Booking booking)
        {
            return await _repository.UpdateAsync(booking);
        }
    }
}
