using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW10.Entities;

namespace HW10.Interfaces
{
    public interface IAuth
    {
        public void Register(string username, string password);
        public void Login(string username, string password);
        public void Logout();
        public User GetCurrentUser();
        public bool IsUserLoggedIn();

    }
}
