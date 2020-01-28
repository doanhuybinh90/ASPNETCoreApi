using Domain.Entities;
using Domain.Interfaces;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AdministratorLoginService : IAdministratorLoginService
    {
        private IAdministratorRepository _repository;

        public AdministratorLoginService(IAdministratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(Administrator administrator)
        {
            if (administrator != null && !string.IsNullOrWhiteSpace(administrator.Email))
            {
                return await _repository.FindByLogin(administrator.Email);
            }
            else
            {
                return null;
            }
        }
    }
}
