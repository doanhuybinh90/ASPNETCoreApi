using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Administrator
{
    public class InputUpdateAdmin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cnpj { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
