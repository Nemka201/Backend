using Backend.Data;
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
    public class GenericRepository<T> : IGenericRepository<T>
   where T : class
    {
        private BackendContext _entities;

        public GenericRepository(BackendContext context)
        {
            _entities = context;
        }
        public BackendContext db
        {

            get { return _entities; }
            set { _entities = value; }
        }
        public virtual List<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query.ToList();
        }
        public List<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query.ToList();
        }
        public virtual void Attach(T entity)
        {
            _entities.Set<T>().Attach(entity);
        }
        public virtual bool Add(T entity)
        {
            _entities.Set<T>().Add(entity);
            return true;
        }
        public virtual bool Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
            return true;
        }
        public virtual bool Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool Save()
        {
            _entities.SaveChanges();
            return true;
        }

        public virtual bool SaveChanges(T entity)
        {
            if (_entities.Entry(entity).State == EntityState.Detached)
            {
                _entities.Set<T>().Attach(entity);
            }
            _entities.Entry(entity).State = EntityState.Modified;
            _entities.SaveChanges();
            return true;
        }
        public virtual T FindById(int id)
        {
            return _entities.Set<T>().Find(id);
        }

        // Async Methdos

        public Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query.ToListAsync();
        }

        public Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query.ToListAsync();
        }

        public ValueTask<EntityEntry<T>> AddAsync(T entity) => _entities.Set<T>().AddAsync(entity);


        public ValueTask<EntityEntry<T>> DeleteAsync(T entity) => _entities.Set<T>().AddAsync(entity);

        public Task SaveAsync() => _entities.SaveChangesAsync();


        public Task SaveChangesAsync(T entity)
        {
            if (_entities.Entry(entity).State == EntityState.Detached)
            {
                _entities.Set<T>().Attach(entity);
            }
            _entities.Entry(entity).State = EntityState.Modified;
            return _entities.SaveChangesAsync();
        }

        public Task<T> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

