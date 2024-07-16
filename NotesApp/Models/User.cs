using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApp.Models
{
	public class User
	{
		public string UserID { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

	}
}
