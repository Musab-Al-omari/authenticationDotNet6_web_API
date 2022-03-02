using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using authenticationDotNet6_web_API.models;
using Microsoft.AspNetCore.Identity;

namespace authenticationDotNet6_web_API.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<User> userManger)
        {


            if (!userManger.Users.Any())
            {
                var users = new List<User>
                {
                    new User{DisplayName="musab",UserName="musab",Email="musab@yahoo.com"},
                    new User{DisplayName="omar",UserName="omar",Email="omar@yahoo.com"},
                    new User{DisplayName="y",UserName="y",Email="y@yahoo.com"}
                };


                foreach (var user in users)
                {
                    await userManger.CreateAsync(user, "Pa$$w0rd");
                }
            }

        }
    }
}