using BookCataloque.Infrastructure.Resolving;

namespace BookCataloque.BL
{
    public abstract class BLCore
    {
        protected IServiceLocator serviceLocator;
        protected IEntityLocator entityLocator;

        public BLCore(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
            this.entityLocator = serviceLocator.GetService<IEntityLocator>();
        }
    }
}
