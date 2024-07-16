using NotesApp.DbContext;
using NotesApp.Interface;
using NotesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace NotesApp.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(User user)
		{
			_context.Add(user);
			return Save();
		}

		public bool Delete(User user)
		{
			_context.Remove(user);
			return Save();
		}

		public async Task<IEnumerable<User>> GetAllUsersAsync()
		{
			return _context.User.ToList();
		}

		public Task<User> GetByIdAsync(string id)
		{
			return _context.User.FirstOrDefaultAsync(x => x.UserID == id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(User user)
		{
			_context.Update(user);
			return Save();
		}
	}
}
