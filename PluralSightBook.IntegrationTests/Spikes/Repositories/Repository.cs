using PluralSightBook.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PluralSightBook.IntegrationTests.Spikes.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        protected DbContext context
        {
            get
            {
                return _context;
            }
        }

        public Repository()
        {
            _context = new PluralSightBookContext();
        }

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this._context.Set<T>();
        }

        public T GetById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public IEnumerable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }

        public void Update(T entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
