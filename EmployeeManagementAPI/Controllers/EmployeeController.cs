using EmployeeManagementAPI.Constants;
using EmployeeManagementAPI.EmployeeDAL;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDAL _employeeDAL;
        public EmployeeController(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }
        
        [HttpGet("get/{id?}")]
        public IActionResult GetEmployee(int? id)
        {
            var result = _employeeDAL.GetEmployee(id ?? 1);
            if (result != null)

                return Ok(new { Response.StatusCode, UserData = result });
            return NotFound("Employee Not Found");
        }

        
        [HttpGet("getall")]
        public IActionResult GetAllEmployee()
        {
            var result = _employeeDAL.GetAllEmployees();
            if (result != null)
                return Ok(result);
            return NotFound("Employee Not Found");
          
        }
        
        [HttpPost("create")]
        public IActionResult AddEmployee(Employee employee)
        {
            return Ok(_employeeDAL.AddEmployee(employee));
        }
        
        [HttpPut("update")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            return Ok(_employeeDAL.UpdateEmployee(employee));
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (_employeeDAL.DeleteEmployee(id) != true)
            {return NotFound(new { messgae = "No Record Found." });}  
            return Ok(new { messgae = "Record deleted successfully." });
        }
    }
}
