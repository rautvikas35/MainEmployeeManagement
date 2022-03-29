using EmployeeManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.EmployeeDAL
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeDAL(EmployeeContext employeeContext)
        {
            _employeeContext=employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
             _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return _employeeContext.Employees.Find(employee.EmployeeId);
        }

        public bool DeleteEmployee(int Id)
        {
            var existingEmp = _employeeContext.Employees.Find(Id);
            if (existingEmp != null)
            {
                _employeeContext.Employees.Remove(existingEmp);
                _employeeContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeContext.Employees.ToList();
        }

        public Employee GetEmployee(int Id)
        {
            //  return _employeeContext.Employees.SingleOrDefault(x => x.EmployeeId == Id);
            return _employeeContext.Employees.Find(Id);

        }

        public Employee UpdateEmployee(Employee employee)
        {
            var existingEmp = _employeeContext.Employees.Find(employee.EmployeeId);
            if(existingEmp !=null)
            {
                existingEmp.EmployeeName = employee.EmployeeName;
                existingEmp.DateOfJoining = employee.DateOfJoining;
                existingEmp.Department = employee.Department;
                _employeeContext.Employees.Update(existingEmp);
                _employeeContext.SaveChanges();
            }
            return employee;
        }
    }
}
