﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }


        public List<Messag> Messages { get; set; }
    }
}
