using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLCar.Core.Data;
using TLCar.Domain.Entity;
using TLCar.PO;

namespace TLCar.Domain.DomainService
{
    public class UserDomainService
    {
        private IRepository<User> _userRepository;
        public UserDomainService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDO Register(string email, string name, string password)
        {
            if(_userRepository.Get(u=>u.Email==email).Count()!=0)
            {
                throw new ArgumentException("email has already existed");
            }
            var user = new UserDO
            {
                guid = Guid.NewGuid(),
                Email = email,
                Name = name,
                Password = password
            };
            return user;
        }
    }
}
