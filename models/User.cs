using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace authenticationDotNet6_web_API.models
{
    public class User : IdentityUser
    {

        public string DisplayName { get; set; }
        public string? Bio { get; set; }

    }
}