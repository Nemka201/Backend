using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Service;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteService _noteService;


        public NotesController(NoteService noteService)
        {
            _noteService = noteService;
        }

        // GET: api/Notes
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Note>> GetNotes()
        {
            return _noteService.GetAllNotes();
        }

        // GET: api/Notes/5
        [HttpGet("Get/{id}")]
        public ActionResult<Note> GetNote(int id)
        {
            var category = _noteService.GetNote(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public IActionResult PutNote(int id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            try
            {
                _noteService.UpdateNote(note);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public ActionResult<Note> PostNote(Note note)
        {
            _noteService.AddNote(note);
            return CreatedAtAction("GetNote", new { id = note.Id }, note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = _noteService.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }
            _noteService.RemoveNote(note);
            return NoContent();
        }

        // Async methods

        // GET: api/Notes
        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotesAsync()
        {
            return _noteService.GetAllNotes();
        }

        // GET: api/Notes/5
        [HttpGet("GetAsync/{id}")]
        public async Task<ActionResult<Note>> GetNoteAsync(int id)
        {
            var category = _noteService.GetNote(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Notes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateAsync/{id}")]
        public async Task<IActionResult> PutNoteAsync(int id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            try
            {
                _noteService.UpdateNote(note);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddAsync")]
        public async Task<ActionResult<Note>> PostNoteAsync(Note note)
        {
            _noteService.AddNote(note);
            return CreatedAtAction("GetNote", new { id = note.Id }, note);
        }

        // DELETE: api/Notes/5
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteNoteAsync(int id)
        {
            var note = _noteService.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }
            _noteService.RemoveNote(note);
            return NoContent();
        }

        private bool NoteExists(int id)
        {
            return _noteService.GetAllNotes().Any(e => e.Id == id);
        }
    }
}
