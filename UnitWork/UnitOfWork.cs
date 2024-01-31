using Backend.Data;
using Backend.Models;
using Backend.Repository;

namespace UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackendContext _context;
        private IGenericRepository<Category> categoryRepository;
        private IGenericRepository<Note> noteRepository;
        private bool _disposed = false;

        public UnitOfWork() 
        {
            _context = new BackendContext();
        }
        public IGenericRepository<Category> CategoryRepository
        {
            get { return categoryRepository ?? (categoryRepository = new GenericRepository<Category>(_context)); } 
        }
        public IGenericRepository<Note> NoteRepository
        {
            get { return noteRepository ?? (noteRepository = new GenericRepository<Note>(_context)); }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task<Task> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
