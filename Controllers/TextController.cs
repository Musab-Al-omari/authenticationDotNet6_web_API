using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace authenticationDotNet6_web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextController : ControllerBase
    {

       
        [HttpGet]
        [Route("text")]

        public async Task<ActionResult<string>> GetText()
        {

            return "your text";
        }


    }
}