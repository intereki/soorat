using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soorat.api.Data;
using soorat.api.Data.Dtos.User;
using soorat.api.Models;

namespace soorat.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        public AdminController(DataContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("usersWithRoles")]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            var userList = await (from user in _context.Users
                                  orderby user.UserName
                                  select new
                                  {
                                    Id = user.Id,
                                    UserName = user.UserName,
                                    Roles = (from userRole in user.UserRoles
                                            join role in _context.Roles
                                            on userRole.RoleId
                                            equals role.Id
                                            select role.Name).ToList()
                                  }).ToListAsync();
            return Ok(userList);
        }

        public struct UsersWithRoles
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public List<string> Roles { get; set; }
        }


        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("editRoles/{userName}")]
        public async Task<IActionResult> EditRoles(string userName, RoleEditDto roleEditDto)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var userRoles = await _userManager.GetRolesAsync(user);

            var selectedRoles = roleEditDto.RoleNames;

            // selectedRoles = selectedRoles != null ? selectedRoles : new string[] {};
            selectedRoles = selectedRoles ?? new string[] {};
            var results = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!results.Succeeded)
                return BadRequest("Failed to add roles");

            results = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!results.Succeeded)
                return BadRequest("Failed to remove roles");

            return Ok(await _userManager.GetRolesAsync(user));

        }

    }
}