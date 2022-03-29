using EmployeeManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.EmployeeDAL
{
   public interface IEmployeeDAL
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int Id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        bool DeleteEmployee(int Id);

    }
}
