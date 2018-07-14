namespace BookCataloque.Infrastructure.Resolving
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}
