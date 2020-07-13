using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDirectory.Models
{
    public class Employee
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        
        public string JobTitle { get; set; }
        
        public DateTime JoiningDate { get; set; }
    }
}
