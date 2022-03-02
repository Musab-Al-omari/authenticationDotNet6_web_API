using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authenticationDotNet6_web_API.Dto
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}