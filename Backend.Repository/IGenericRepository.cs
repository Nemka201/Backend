using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Backend.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> FindBy(Expression<Func<T, bool>> predicate);
        bool Add(T entity);
        bool Delete(T entity);
        bool Edit(T entity);
        bool Save();
        bool SaveChanges(T entity);
        T FindById(int id);

        // Async methods

        Task<List<T>> GetAllAsync();
        Task <List<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        ValueTask<EntityEntry<T>> AddAsync(T entity);
        ValueTask<EntityEntry<T>> DeleteAsync(T entity);
        Task SaveAsync();
        Task SaveChangesAsync(T entity);
        Task<T> FindByIdAsync(int id);
    }

}
