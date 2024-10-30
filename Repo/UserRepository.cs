using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HW10.Entities;
using HW10.Interfaces;
using Newtonsoft.Json;

namespace HW10.Repo
{
    public class UserRepository : IUserRepository
    {
        private string FilePath = "users.json";
        List<User> _users = new List<User>();

        public UserRepository()
        {
            _users = LoadUsersFromFile();
        }

        public void Register(string username, string password)
        {
            if (_users.Any(u => u.Username == username))
            {
                Console.WriteLine("Registration failed! A user already exists with this username.");
                return;
            }
            var newUser = new User(username, password);
            _users.Add(newUser);
            SaveUsersInFile();
            Console.WriteLine("Register Successful!");
        }

        public bool Login(string username, string password)
        {
            bool checkLogin = false;
            foreach (var item in _users)
            {
                if (item.Username == username && item.Password == password)
                {

                    return true;
                }
            }



            return false;
        }

        public bool ChangeStatus(User currentuser, bool status)
        {
            var user = _users.Find(u => u == currentuser);

            user.IsActive = status;
            SaveUsersInFile();
            return status;



        }

        public bool changePassword(User currentuser, string OldPassword, string NewPassword)
        {
            if (currentuser.Password == OldPassword)
            {
                currentuser.Password = NewPassword;

                SaveUsersInFile();
                return true;
            }
            else if (currentuser.Password != OldPassword)
            {
                Console.WriteLine("Old Pass is wrong!");
            }
            return false;


        }

        public List<User> Search(string searchWord)
        {


            return _users.FindAll(u => u.Username.StartsWith(searchWord));


        }

        public void SaveUsersInFile()
        {
            var JsonData = JsonConvert.SerializeObject(_users, Formatting.Indented);
            File.WriteAllText(FilePath, JsonData);

        }

        public List<User> LoadUsersFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return new List<User> { };
            }
            var JsonData = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<User>>(JsonData);

        }

        public User GetUserByUsername(string username)
        {
            return _users.Find(u => u.Username == username);
        }
    }
}
