using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTOs.Bookings
{
    public class InputUpdateBooking
    {
        public Guid  Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        public decimal Price { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
