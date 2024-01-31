using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service
{
    public interface INoteService
    {
        public Note GetNote(int id);
        public List<Note> GetAllNotes();
        public void AddNote(Note note);
        public void RemoveNote(Note note);
        public void UpdateNote(Note note);
        public Task<Note> GetNoteAsync(int id);
        public Task<List<Note>> GetAllNotesAsync();
        public Task AddNoteAsync(Note note);
        public Task RemoveNoteAsync(Note note);
        public Task UpdateNoteAsync(Note note);
    }
}
