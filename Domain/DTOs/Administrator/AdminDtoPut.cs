using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTOs.Administrator
{
    public class AdminDtoPut
    {
        public Guid  Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name must be a maximum of {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        [StringLength(100, ErrorMessage = "Email must be a maximum {1} characters")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cnpj { get; set; }
    }
}
