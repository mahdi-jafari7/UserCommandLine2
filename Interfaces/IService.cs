using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW10.Entities;

namespace HW10.Interfaces
{
    public interface IService
    {
        public void Search(string SearchWord);
        public void ChangePassword(User currentuser, string OldPassword, string NewPassword);
        public void ChangeStatus(User currentuser, bool Status);

    }
}
