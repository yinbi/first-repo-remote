using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLCar.Service.IService;
using TLCar.Domain.Entity;
using TLCar.Core.Data;
using TLCar.Domain.DomainService;
using TLCar.Core.Common;
using TLCar.DTO;
using AutoMapper;
using TLCar.PO;

namespace TLCar.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow;
        private IRepository<User> _userRepository;
        public UserService(IUnitOfWork uow,IRepository<User> userRepository)
        {
            _uow = uow;
            _userRepository = userRepository;
        }
        protected virtual UserDomainService DomainService
        {
            get
            {
                return EngineContext.Current.Resolve<UserDomainService>();
            }
        }
        public void Register(string email, string name, string password)
        {
            var userDo = DomainService.Register(email, name, password);
            Mapper.CreateMap<UserDO, User>();
            User user = Mapper.Map<UserDO, User>(userDo);
            _userRepository.Insert(user);
            _uow.SaveChanges();

        }
    }
}
