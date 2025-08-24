
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]                                        // Only users with Admin role can access this controller
public class AdminController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AdminController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    // POST api/admin/assign-role
    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole(string email, string role)
    {
        // Find the user by their email address
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)  // If no user found with that email
            return NotFound("User not found");

        // Add the specified role to the user asynchronously
        var result = await _userManager.AddToRoleAsync(user, role);
        if (result.Succeeded)                       // If role assignment succeeded
            return Ok($"Role '{role}' assigned to {email}");

        //else
        return BadRequest(result.Errors);
    }
}
