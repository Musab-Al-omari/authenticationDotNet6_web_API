using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authenticationDotNet6_web_API.Dto
{
    public class UserReturnDto
    {
        public string token { get; set; }
        public string DisplayName { get; set; }
    }
}