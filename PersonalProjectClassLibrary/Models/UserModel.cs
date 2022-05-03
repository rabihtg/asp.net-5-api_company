﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
