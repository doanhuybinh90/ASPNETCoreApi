﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTOs.Bookings
{
    public class InputCreateBooking
    {
        public Guid Id;
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        /*public Entities.Administrator Administrator { get; set; }
        public Entities.Visitor Visitor { get; set; }*/
        public DateTime CreateAt { get; set; }
    }
}
