using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Administrator : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cnpj { get; set; }
        public List<Booking> Bookings { get; set; }
    }

    
}
