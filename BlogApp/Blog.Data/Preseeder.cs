using Blog.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class Preseeder
    {

        private const string adminPassword = "Secret@123";
        private const string regularPassword = "P@ssw0rd";

        public async static void EnsurePopulated(IApplicationBuilder app)
        {
            //Get db context
            var _context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (_context.Database.GetPendingMigrations().Any())
            {
                _context.Database.Migrate();
            }

            if (_context.Posts.Any())
            {
                return;
            }
            else
            {
                //Get Usermanager and rolemanager from IoC container
                var userManager = app.ApplicationServices.CreateScope()
                                              .ServiceProvider.GetRequiredService<UserManager<Author>>();

                var roleManager = app.ApplicationServices.CreateScope()
                                                .ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                //Create role if it doesn't exists
                var roles = new string[] { "Admin", "Regular" };
                foreach (var role in roles)
                {
                    var roleExist = await roleManager.RoleExistsAsync(role);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }


                var posts = GetSampleData();
                _context.Posts.AddRange(posts);
                await _context.SaveChangesAsync();

                ////Seed Users with 1(one) Admin User
                //var appUsers = GetSampleData<Author>(File.ReadAllText(path + "Customer.json"));
                //var (adminCount, customerCount) = (0, 0);

                //foreach (var user in appUsers)
                //{
                //    if (adminCount < 1)
                //    {
                //        await userManager.CreateAsync(user, adminPassword);
                //        await userManager.AddToRoleAsync(user, roles[0]);
                //        ++adminCount;
                //    }
                //    else
                //    {
                //        await userManager.CreateAsync(user, regularPassword);
                //        await userManager.AddToRoleAsync(user, roles[1]);
                //        ++customerCount;
                //    }

                //    ConfirmUserEmail(user, userManager);

                //}
            }
        }

        //Get sample data from json files
        private static List<Post> GetSampleData()
        {
            return new List<Post>
            {
                new Post{Title="Work Great",Description="A great way to work"},
                new Post{Title="Test",Description="A test applictation"},
                new Post{Title="Midnight Life",Description="Burning the midnight oil"},
                new Post{Title="Good Life",Description="The Good life"}
            };
        }

        ////Confirm seeded user email.
        //private static async void ConfirmUserEmail(AppUser user, UserManager<AppUser> userManager)
        //{
        //    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        //    await userManager.ConfirmEmailAsync(user, token);
        //}
    }
}
