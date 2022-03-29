using EmployeeManagementAPI.Models;
using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagementAPI.EmployeeDAL
{
    public class UserDAL : IUserDAL
    {
        private readonly EmployeeContext _employeeContext;
        public UserDAL(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public User Authenticate(User User)
        {
            var user= _employeeContext.Users.FirstOrDefault
                (x => x.UserName == User.UserName && x.Password == User.Password);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes("This is the Sample Key for User Login");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(user.UserName)),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.Version, "V3.1"),
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            var tokenstring = new JwtSecurityTokenHandler().ReadJwtToken(user.Token);
            var claim = tokenstring.Claims.First(c => c.Type == "unique_name").Value;
            return user;
        }
    }
}
