using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Messag
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
