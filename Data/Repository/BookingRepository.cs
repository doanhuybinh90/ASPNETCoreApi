using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {

        public override async Task<Booking> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.Include(p => p.Administrator).SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<Booking> InsertAsync(Booking item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }
                item.CreateAt = DateTime.UtcNow;

                _context.Administrators.Attach(item.Administrator);
                _dataset.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }
    }
}
