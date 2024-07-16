using NotesApp.Models;

namespace NotesApp.Interface
{
	public interface IUserRepository
	{
		Task<User> GetByIdAsync(string id);
		Task<IEnumerable<User>> GetAllUsersAsync();
		bool Add(User user);
		bool Update(User user);
		bool Delete(User user);
		bool Save();
	}
}
