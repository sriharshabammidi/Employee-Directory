using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectory.API.Helpers;
using EmployeeDirectory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeDirectory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly JwtIssuerOptions _jwtIssuerOptions;
        public SecurityController(JwtIssuerOptions jwtIssuerOptions)
        {
            _jwtIssuerOptions = jwtIssuerOptions;
        }
        
        [HttpPost]
        [Route("login")]
        public IActionResult LogIn(LoginRequest loginRequest)
        {
                if (("testuser").Equals(loginRequest.UserName,StringComparison.OrdinalIgnoreCase) && ("Test@123").Equals(loginRequest.Password)){
                    return Ok(JwtTokenHelper.GenerateJSONWebToken(this._jwtIssuerOptions, "sriwithsweetsmile@gmail.com"));
                }
                else
                {
                    return Unauthorized("Invalid username or password!");
                }
        }

        [Authorize]
        [HttpGet]
        [Route("test")]
        public void Test()
        {

        }

    }
}
