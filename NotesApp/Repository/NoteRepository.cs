using NotesApp.DbContext;
using NotesApp.Interface;
using NotesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace NotesApp.Repository
{
	public class NoteRepository : INoteRepository
	{
		private readonly AppDbContext _context;
		public NoteRepository(AppDbContext context)
		{
			_context = context;
		}
		public bool Add(Note note)
		{
			_context.Add(note);
			return Save();
		}

		public bool Delete(Note note)
		{
			_context.Remove(note);
			return Save();
		}

		public async Task<IEnumerable<Note>> GetAllNotesAsync()
		{
			return _context.Note.ToList();
		}
		public async Task<IEnumerable<Note>> GetNotesByUserIdAsync(string userId)
		{
			return await _context.Note.Where(n => n.UserID == userId).ToListAsync();
		}
		public async Task<Note> GetByIdAsync(string id)
		{
			return await _context.Note.FirstOrDefaultAsync(x => x.NoteId == id);

		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Note note)
		{
			_context.Update(note);
			return Save();
		}
	}
}
