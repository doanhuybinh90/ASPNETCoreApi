﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Visitor : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
    }
}
