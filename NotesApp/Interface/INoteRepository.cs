using NotesApp.Models;

namespace NotesApp.Interface
{
	public interface INoteRepository
	{
		Task<IEnumerable<Note>> GetAllNotesAsync();
		Task<Note> GetByIdAsync(string id);
		Task<IEnumerable<Note>> GetNotesByUserIdAsync(string userId);
		bool Add(Note note);
		bool Update(Note note);
		bool Delete(Note note);
		bool Save();
	}
}
