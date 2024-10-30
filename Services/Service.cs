using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW10.Entities;
using HW10.Interfaces;

namespace HW10.Services
{
    public class Service : IService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuth _auth;
        public Service(IUserRepository userRepository, IAuth auth)
        {
            _userRepository = userRepository;
            _auth = auth;
        }

        public void Search(string SearchWord)
        {
            if (!_auth.IsUserLoggedIn())
            {
                Console.WriteLine("this command only available after login");
                return;
            }

            var result = _userRepository.Search(SearchWord);

            if (result.Count == 0)
            {
                Console.WriteLine("No matching users found.");
            }
            else
            {
                foreach (var user in result)
                {

                    Console.WriteLine($"{user.Username} | status of Availability: {user.IsActive}");
                }
            }

        }


        public void ChangePassword(User currentuser, string OldPassword, string NewPassword)
        {
            var CR = _auth.GetCurrentUser();
            var result = _userRepository.changePassword(CR, OldPassword, NewPassword);
            if (result)
            {
                Console.WriteLine("Password Has Changed Successfully!");
            }
            else
            {
                Console.WriteLine("Old Password is Wrong!");
            }
        }

        public void ChangeStatus(User currentuser, bool Status)
        {
            var CR = _auth.GetCurrentUser();
            var result = _userRepository.ChangeStatus(CR, Status);
            if (result == true)
            {
                Console.WriteLine($"Username '{CR.Username}' Activated!");
            }
            else
            {
                Console.WriteLine($"Username '{CR.Username}' DeActivated!");
            }
        }

    }
}
