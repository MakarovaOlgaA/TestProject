using BookCataloque.Infrastructure.Resolving;
using Unity;

namespace BookCataloque.Bootstrap.DependencyResolving
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IUnityContainer container;

        public ServiceLocator(IUnityContainer container)
        {
            this.container = container;
        }

        public T GetService<T>()
        {
            return container.Resolve<T>();
        }
    }
}
