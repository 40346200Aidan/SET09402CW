using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    public class Driver : User
    {
        public Driver() { }

        public Driver(int employeeUserId, string employeeFullname, string employeeEmail, string employeeNumber, Role employeeRoleEnum, string employeeAddress, string employeeQualification)
        {
            this.UserId = employeeUserId;
            this.Fullname = employeeFullname;
            this.Email = employeeEmail;
            this.PhoneNumber = employeeNumber;
            this.UserRole = employeeRoleEnum;
            this.Address = employeeAddress;
            this.Qualification = employeeQualification;
        }

        


    }

    
}
