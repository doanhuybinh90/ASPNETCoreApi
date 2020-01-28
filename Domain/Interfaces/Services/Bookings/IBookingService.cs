using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Bookings
{
    public interface IBookingService
    {
        Task<Booking> Get(Guid id);
        Task<IEnumerable<Booking>> GetAll();
        Task<Booking> Post(Booking booking);
        Task<Booking> Put(Booking booking);
        Task<bool> Delete(Guid id);
    }
}
