using AutoMapper;

namespace BookCataloque.Infrastructure
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
            });
        }
    }
}