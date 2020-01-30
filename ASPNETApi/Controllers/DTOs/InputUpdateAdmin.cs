using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETApi.Controllers.DTOs
{
    public class InputUpdateAdmin
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cnpj { get; set; }
    }
}
