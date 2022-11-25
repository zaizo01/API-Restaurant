﻿using Microsoft.AspNetCore.Identity;
using StockApp.Core.Application.Enums;
using StockApp.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infrastructure.Identity.Seeds
{
    public static class DefaultWaiterUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.UserName = "waiterUser";
            defaultUser.Email = "waiter@email.com";
            defaultUser.FirstName = "Pedrito";
            defaultUser.LastName = "Martinez";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if(userManager.Users.All(u=> u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Waiter.ToString());
                }
            }
         
        }
    }
}
