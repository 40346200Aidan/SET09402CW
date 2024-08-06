using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    public class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Role UserRole { get; set; }
        public string? Address { get; set; }
        public string? Qualification {get; set; }

        
    }
    public enum Role
    {
        driver,
        administrator,
        customer
    }
}
