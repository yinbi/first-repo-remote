using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLCar.Core.Data;

namespace TLCar.Data
{
    public class MyDataBase : DbContext, IUnitOfWork
    {
        public MyDataBase(string connStr)
            : base(connStr)
        {

        }
    }
}
