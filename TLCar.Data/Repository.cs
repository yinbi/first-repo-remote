using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TLCar.Core;
using TLCar.Core.Data;

namespace TLCar.Data
{
    public class Repository<T> : IRepository<T> where T : class, IAggregageRoot
    {
        private DbContext _context;

        //public Repository(IUnitOfWork uow)
        //{
        //    if (uow == null)
        //    {
        //        throw new ArgumentNullException("uow");
        //    }
        //    _context = uow as TLCarDataBase;
        //}
        public Repository(DbContext dbcontext)
        {
            if (dbcontext == null)
            {
                throw new ArgumentNullException("dbcontext");
            }
            _context = dbcontext;
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> Table
        {
            get
            {
                return _context.Set<T>().AsQueryable();
            }
        }

        public bool Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            return true;
        }
        public bool Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return true;
        }


        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
