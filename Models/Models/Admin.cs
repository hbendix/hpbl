using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
