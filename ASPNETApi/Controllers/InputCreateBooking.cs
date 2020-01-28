using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETApi.Controllers
{
    public class InputCreateBooking
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid AdminId { get; set; }
        public Guid VisitorId { get; set; }
    }
}
