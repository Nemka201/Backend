using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitWork;

namespace Backend.Service
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NoteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddNote(Note note)
        {
            _unitOfWork.NoteRepository.Add(note);
            _unitOfWork.Save();
        }

        public async Task AddNoteAsync(Note note)
        {
            await _unitOfWork.NoteRepository.AddAsync(note);
            _unitOfWork.SaveAsync();
        }

        public List<Note> GetAllNotes()
        {
            return _unitOfWork.NoteRepository.GetAll();
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Note GetNote(int id)
        {
            return _unitOfWork.NoteRepository.FindById(id);
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            return await _unitOfWork.NoteRepository.FindByIdAsync(id);
        }

        public void RemoveNote(Note note)
        {
            _unitOfWork.NoteRepository.Delete(note);
            _unitOfWork.Save();
        }

        public Task RemoveNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public void UpdateNote(Note note)
        {
            _unitOfWork.NoteRepository.Edit(note);
        }

        public Task UpdateNoteAsync(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
