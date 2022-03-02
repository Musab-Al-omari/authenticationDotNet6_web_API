using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authenticationDotNet6_web_API.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace authenticationDotNet6_web_API.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DataContext(DbContextOptions options) : base(options) { }

    }
}