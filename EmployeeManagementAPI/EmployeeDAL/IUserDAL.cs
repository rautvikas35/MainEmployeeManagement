using EmployeeManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.EmployeeDAL
{
   public interface IUserDAL
    {
        User Authenticate(User user);
    }
}
