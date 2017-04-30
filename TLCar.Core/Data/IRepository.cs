using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TLCar.Core.Data
{
    public interface IRepository<T> : IQuery<T> where T : IAggregageRoot
    {
        T GetById(Guid id);
        IEnumerable<T> Get(Expression<Func<T, Boolean>> predicate);
        IEnumerable<T> GetAll();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
