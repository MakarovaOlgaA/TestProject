using AutoMapper;
using BookCataloque.BL.Interfaces;
using BookCataloque.DAL.Interfaces;

namespace BookCataloque.Infrastructure
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<IBookVM, IBookEM>().ReverseMap();
                cfg.CreateMap<IAuthorVM, IAuthorEM>().ReverseMap();
                cfg.CreateMap<IAuthorFilterVM, IAuthorFilterEM>().ReverseMap();
                cfg.CreateMap<IBookFilterVM, IBookFilterEM>().ReverseMap();
            });
        }
    }
}