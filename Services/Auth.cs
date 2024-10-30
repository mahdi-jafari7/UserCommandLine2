using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW10.Entities;
using HW10.Interfaces;

namespace HW10.Services
{
    public class Auth : IAuth
    {

        private readonly IUserRepository _userRepository;
        public User _currentUser;


        public Auth(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(string username, string password)
        {

            _userRepository.Register(username, password);
        }

        public void Login(string username, string password)
        {
            if (_userRepository.Login(username, password))
            {
                _currentUser = _userRepository.GetUserByUsername(username);
                Console.WriteLine("Login Successful");
            }
            else
            {
                Console.WriteLine("Login Failed. username or password is incorrect...");

            }
        }

        public void Logout()
        {
            if (_currentUser != null)
            {
                _currentUser = null;
                Console.WriteLine("Logout successful!");
            }
            else
            {
                Console.WriteLine("Error: No user is currently logged in.");
            }
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        public bool IsUserLoggedIn()
        {
            if (_currentUser != null)
            {
                return true;
            }
            return false;
        }
    }
}
