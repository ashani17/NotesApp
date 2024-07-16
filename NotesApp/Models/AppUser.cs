using Microsoft.AspNetCore.Identity;
namespace NotesApp.Models
{
	public class AppUser : IdentityUser
	{
		public string UserName { get; set; }
		public string Email { get; set; }

		
	}
}
