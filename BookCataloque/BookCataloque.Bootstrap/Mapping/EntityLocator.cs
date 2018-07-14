using BookCataloque.Infrastructure.Resolving;
using AutoMapper;

namespace BookCataloque.Bootstrap.Mapping
{
    public class EntityLocator: IEntityLocator
    {
        public T ConvertTo<T>(object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}
