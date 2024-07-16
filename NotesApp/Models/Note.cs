using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApp.Models
{
	public class Note
	{
		public string NoteId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string UserID { get; set; }
	}
}
