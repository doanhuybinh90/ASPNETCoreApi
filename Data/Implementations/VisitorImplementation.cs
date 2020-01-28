using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class VisitorImplementation : BaseRepository<Visitor>, IVisitorRepository
    {
        private DbSet<Visitor> _dataset;

        public VisitorImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<Visitor>();
        }

        public async Task<Visitor> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
