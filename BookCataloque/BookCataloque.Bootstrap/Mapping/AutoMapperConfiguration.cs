﻿using AutoMapper;
using BookCataloque.EntityModel;
using BookCataloque.ViewModel;

namespace BookCataloque.Bootstrap.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<BookVM, BookEM>().ReverseMap();
                cfg.CreateMap<AuthorVM, AuthorEM>().ReverseMap();
                cfg.CreateMap<AuthorFilterVM, AuthorFilterEM>().ReverseMap();
                cfg.CreateMap<BookFilterVM, BookFilterEM>().ReverseMap();
            });
        }
    }
}