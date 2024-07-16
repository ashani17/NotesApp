using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotesApp.DTO.UserDTO;
using NotesApp.Models;

namespace NotesApp.Controllers
{
	
		[ApiController]
		[Route("api/[controller]")]
		public class AuthController : ControllerBase
		{
			private readonly UserManager<AppUser> _userManager;
			private readonly SignInManager<AppUser> _signInManager;

			public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
			{
				_userManager = userManager;
				_signInManager = signInManager;
			}

			[HttpPost("register")]
			public async Task<IActionResult> Register([FromBody] PostUserDTO model)
			{
				var user = new AppUser { UserName = model.UserName, Email = model.Email };
				var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
				{
					return Ok(new { Message = "User registered successfully" });
				}

				return BadRequest(result.Errors);
			}

			[HttpPost("login")]
			public async Task<IActionResult> Login([FromBody] PostUserDTO model)
			{
				var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
				if (result.Succeeded)
				{
					return Ok(new { Message = "User logged in successfully" });
				}

				return Unauthorized();
			}
		}
	}

