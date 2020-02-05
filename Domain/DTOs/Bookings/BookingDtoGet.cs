using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTOs.Bookings
{
    public class BookingDtoGet
    {
        public Guid Id { get; set; }

        [Required (ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name must be a maximum of {1} characters ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(120, ErrorMessage ="Must be a maximum of {1} characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

       





    }
}
