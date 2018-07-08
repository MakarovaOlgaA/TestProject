using BookCataloque.BL;
using BookCataloque.BL.Interfaces;
using BookCataloque.DAL;
using BookCataloque.DAL.Interfaces;
using System;

using Unity;

namespace BookCataloque
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
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
            container.RegisterType<IBLCore, BLCore>();
            container.RegisterType<IBookRepository, BookRepository>();
        }
    }
}