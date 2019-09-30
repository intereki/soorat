using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using soorat.api.Models;

namespace soorat.api.Data.SeedData
{
    public class Seed
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public Seed(DataContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public void SeedData()
        {
            SeedBazarData();
            SeedUsers();
        }

        public void SeedBazarData()
        {
            Bazar bazar = new Bazar 
            {
                Name = "چراغ برق",
                Address = "میدان بهارستان - خیابان اکباتان"
            };

            _context.Bazar.Add(bazar);
            _context.SaveChanges();
        }
    

        public void SeedUsers()
        {
            if (!_userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/SeedData/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                var roles = new List<Role>
                {
                    new Role {Name = "Store"},
                    new Role {Name = "Admin"},
                    new Role {Name = "Operator"}
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }                

                foreach (var user in users)
                {
                    _userManager.CreateAsync(user, "123456").Wait();
                    _userManager.AddToRoleAsync(user, "Store").Wait();
                }

                var admin = _userManager.FindByNameAsync("09129318724").Result;
                _userManager.AddToRolesAsync(admin, new[] { "Admin", "Store", "Operator" }).Wait();                
            }
        }
    }
}