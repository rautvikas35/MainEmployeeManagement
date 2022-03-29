using EmployeeManagementAPI.EmployeeDAL;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDAL _userDAL;

        public UserController(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        /// <summary>
        /// Get valid User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromBody] User User)
        {
            var user = _userDAL.Authenticate(User);
            if (user != null)
            {
               return Ok(user);
            }
            return NotFound("User Not Found...");
        }

        
    }
}
