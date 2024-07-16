using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotesApp.DbContext;
using NotesApp.DTO.NoteDTO;
using NotesApp.Interface;
using NotesApp.Models;

namespace NotesApp.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class NotesController : ControllerBase
		{
			private readonly INoteRepository _noteRepository;
			private readonly UserManager<AppUser> _userManager;

            public NotesController(INoteRepository noteRepository, UserManager<AppUser> userManager)
            {
				_noteRepository = noteRepository;
				_userManager = userManager;

			}


			[HttpGet]
			public async Task<IActionResult> GetAll()
			{
				var userId = _userManager.GetUserId(User);
				var notes = await _noteRepository.GetNotesByUserIdAsync(userId);
				return Ok(notes);
			}

			[HttpGet("{id}")]
			public async Task<IActionResult> GetById(string id)
			{
				var userId = _userManager.GetUserId(User);
				var note = await _noteRepository.GetByIdAsync(id);

				if (note == null || note.UserID != userId)
				{
					return NotFound();
				}

				return Ok(note);
			}

			[HttpPost]
			public async Task<IActionResult> Create(PostNoteDTO noteDto)
			{
				var userId = _userManager.GetUserId(User);

				var note = new Note
				{
					Title = noteDto.Title,
					Content = noteDto.Content,

					UserID = userId
				};

				_noteRepository.Add(note);
				_noteRepository.Save();

				return CreatedAtAction(nameof(GetById), new { id = note.NoteId }, note);
			}

			[HttpPut("{id}")]
			public async Task<IActionResult> Update(string id, PutNoteDTO noteDto)
			{
				var userId = _userManager.GetUserId(User);

				var note = await _noteRepository.GetByIdAsync(id);

				if (note == null || note.UserID != userId)
				{
					return NotFound();
				}

				note.Title = noteDto.Title;
				note.Content = noteDto.Content;

				_noteRepository.Update(note);
				_noteRepository.Save();

				return NoContent();
			}

			[HttpDelete("{id}")]
			public async Task<IActionResult> Delete(string id)
			{
				var userId = _userManager.GetUserId(User);
				var note = await _noteRepository.GetByIdAsync(id);

				if (note == null || note.UserID != userId)
				{
					return NotFound();
				}

				_noteRepository.Delete(note);
				_noteRepository.Save();

				return NoContent();
			}
		}
	}
