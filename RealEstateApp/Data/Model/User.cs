﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }
        public bool Active { get; set; }
    }
}
