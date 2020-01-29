using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETApi.Controllers
{
    public class InputCreateBooking
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Administrator Id is Required")]
        public Guid AdminId { get; set; }
        [Required(ErrorMessage = "Visitor Id is Required")]
        public Guid VisitorId { get; set; }
    }
}
