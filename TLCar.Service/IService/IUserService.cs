using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLCar.Domain.Entity;

namespace TLCar.Service.IService
{
    public interface IUserService
    {
        void Register(string email, string name, string password);
    }
}
