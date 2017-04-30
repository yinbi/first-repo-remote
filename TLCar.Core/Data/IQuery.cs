using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLCar.Core.Data
{
    public interface IQuery<T>
    {
        T GetById(int id);
        IQueryable<T> Table { get; }
    }
}
