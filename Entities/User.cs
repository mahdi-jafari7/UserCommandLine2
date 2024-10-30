using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10.Entities
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
