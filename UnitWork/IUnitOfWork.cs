using Backend.Models;
using Backend.Repository;

namespace UnitWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Note> NoteRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        void Save();
        Task<Task> SaveAsync();

    }
}
