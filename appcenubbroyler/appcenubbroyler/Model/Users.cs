using System;
using System.Collections.Generic;
using System.Text;

namespace appcenubbroyler.Model
{
    public class Users
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Sname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }

    }
}
