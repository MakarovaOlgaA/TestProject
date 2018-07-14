using BookCataloque.Infrastructure.Business;
using BookCataloque.Infrastructure.Data;
using BookCataloque.BL;
using BookCataloque.DAL;
using BookCataloque.Infrastructure.Resolving;
using System;
using Unity;
using BookCataloque.Bootstrap.Mapping;
using Unity.Injection;

namespace BookCataloque.Bootstrap.DependencyResolving
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnitySetup
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IServiceLocator>(new InjectionFactory(c => CreateFactory()));
            container.RegisterType<IEntityLocator, EntityLocator>();
            container.RegisterType<IBLCore, BLCore>();
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
        }

        public static IServiceLocator CreateFactory()
        {
            return new ServiceLocator(container.Value);
        }
    }
}