using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW10.Entities;

namespace HW10.Interfaces
{
    public interface IUserRepository
    {
        public void Register(string username, string password);
        public bool Login(string username, string password);
        public bool ChangeStatus(User currentuser, bool status);
        public bool changePassword(User currentuser, string OldPassword, string NewPassword);
        public List<User> Search(string searchWord);
        public void SaveUsersInFile();
        public List<User> LoadUsersFromFile();
        public User GetUserByUsername(string username);

    }
}
