using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
