using PluralSightBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.IntegrationTests.Spikes.Repositories
{
    public interface IQueryableRepository<T>
    {
        IQueryable<T> List();
    }

    public class QueryableFriendRepo : Repository<Friend>, IQueryableRepository<Friend>
    {
        public QueryableFriendRepo(DbContext context) : base(context)
        {
        }
        public IQueryable<Friend> List()
        {
            return context.Set<Friend>();
        }
    }
}
