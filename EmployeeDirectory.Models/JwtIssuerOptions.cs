using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDirectory.Models
{
    public class JwtIssuerOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
