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
    public class AdministratorImplementation : BaseRepository<Administrator>, IAdministratorRepository
    {
        private DbSet<Administrator> _dataset;

        public AdministratorImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<Administrator>();
        }

        public async Task<Administrator> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
