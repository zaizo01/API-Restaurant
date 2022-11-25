﻿using Microsoft.AspNetCore.Identity;
using Restaurant.Core.Application.Enums;
using Restaurant.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Identity.Seeds
{
    public class DefaultSuperAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.UserName = "superAdminUser";
            defaultUser.Email = "superadmin@email.com";
            defaultUser.FirstName = "Super";
            defaultUser.LastName = "Admin";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Waiter.ToString());
                }
            }

        }
    }
}
