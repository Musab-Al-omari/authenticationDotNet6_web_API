using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authenticationDotNet6_web_API.Dto
{
    public class RegisterDto
    {
        public string Username { get; set; }

        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$",ErrorMessage ="PASSWORD MUST BE COMPLEX")]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string DisplayName => Email.Split("@")[0];
    }
}