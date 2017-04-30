using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLCar.Core.Common.DependencyManagement
{
    public class DepedencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //throw new NotImplementedException();
            // builder.RegisterType<ProductRepository>().As<IProductRepository>();
            //    builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())//查找程序集中以Repository结尾的类型
            //.Where(t => t.Name.EndsWith("Repository"))
            //.AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())//查找程序集中以Repository结尾的类型
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();

        }

        public int Order
        {
            //get { throw new NotImplementedException(); }
            get { return 0; }
        }
    }
}
