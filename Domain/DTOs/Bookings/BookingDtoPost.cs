using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Domain.DTOs.Bookings
{
    public class BookingDtoPost
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        public decimal Price { get; set; }
        public Guid AdminId { get; set; }
        public Guid VisitorId { get; set; }





    }
}
