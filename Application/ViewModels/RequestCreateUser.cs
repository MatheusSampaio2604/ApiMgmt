﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class RequestCreateUser
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
