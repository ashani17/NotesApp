using Microsoft.AspNetCore.Mvc;

namespace NotesApp.Controllers
{
	public class UsersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
