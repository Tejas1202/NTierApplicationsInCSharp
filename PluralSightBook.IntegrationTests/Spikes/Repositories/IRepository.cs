using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.IntegrationTests.Spikes.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Query(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        void Save();
    }
}
