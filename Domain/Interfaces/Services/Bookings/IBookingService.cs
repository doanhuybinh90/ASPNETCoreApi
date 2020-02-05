using Domain.DTOs.Bookings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Bookings
{
    public interface IBookingService
    {
        Task<BookingDtoGet> Get(Guid id);
        Task<IEnumerable<BookingDtoGet>> GetAll();
        Task<InputCreateBooking> Post(BookingDtoPost booking);
        Task<InputUpdateBooking> Put(BookingDtoPut booking);
        Task<bool> Delete(Guid id);
    }
}
