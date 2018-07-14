namespace BookCataloque.Infrastructure.Resolving
{
    public interface IEntityLocator
    {
        T ConvertTo<T>(object source);
    }
}
