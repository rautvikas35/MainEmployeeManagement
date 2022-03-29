using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Name should not exceed 50 characters.")]
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
