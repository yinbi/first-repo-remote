using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLCar.Core.Common.DependencyManagement;

namespace TLCar.Core.Common
{
    public class Engine : IEngine
    {
        #region Fields
        private ContainerManager _containerManager;
        #endregion

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        /// <summary>
        ///  Resolve dependency
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }

        /// <summary>
        /// Container manager
        /// </summary>
        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        public void Initialize()
        {
            #region
            //var builder = new ContainerBuilder();
            //var container = builder.Build();

            ////dependencies
            //var typeFinder = new AppDomainTypeFinder();
            //builder = new ContainerBuilder();
            //builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            //builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            //builder.Update(container);

            ////register dependencies provided by other assemblies
            //builder = new ContainerBuilder();
            //var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            //var drInstances = new List<IDependencyRegistrar>();

            //foreach (var drType in drTypes)
            //{
            //    drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            //}

            ////sort
            //drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            //foreach (var dependencyRegistrar in drInstances)
            //    dependencyRegistrar.Register(builder, typeFinder);
            //builder.Update(container);

            //this._containerManager = new ContainerManager(container);
            #endregion

            var builder = new ContainerBuilder();
            var container = builder.Build();

            //dependencies
            var typeFinder = new AppDomainTypeFinder();
            builder = new ContainerBuilder();
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            builder.Update(container);

            //register dependencies provided by other assemblies
            builder = new ContainerBuilder();
            var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = new List<IDependencyRegistrar>();

            foreach (var drType in drTypes)
            {
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            }

            //sort
            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.Register(builder, typeFinder);
            builder.Update(container);

            this._containerManager = new ContainerManager(container);


        }
    }
}
