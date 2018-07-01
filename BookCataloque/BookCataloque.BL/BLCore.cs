using System.Collections.Generic;
using BookCataloque.BL.Interfaces;
using BookCataloque.DAL.Interfaces;
using AutoMapper;
using Unity.Attributes;

namespace BookCataloque.BL
{
    public class BLCore : IBLCore
    {
        private ICataloqueRepository repo;

        [InjectionConstructor]
        public BLCore(ICataloqueRepository repo)
        {
            this.repo = repo;
        }

        public void AddAuthor(IAuthorVM author)
        {
            repo.AddAuthor(Mapper.Map<IAuthorEM>(author));
        }

        public void AddBook(IBookVM book)
        {
            repo.AddBook(Mapper.Map<IBookEM>(book));
        }

        public bool DeleteAuthor(int authorID)
        {
            return repo.DeleteAuthor(authorID);
        }

        public bool DeleteBook(int bookID)
        {
            return repo.DeleteBook(bookID);
        }

        public IAuthorVM GetAuthor(int authorID)
        {
            return Mapper.Map<IAuthorVM>(repo.GetAuthor(authorID));
        }

        public IEnumerable<IAuthorVM> GetAuthors()
        {
            return Mapper.Map<IEnumerable<IAuthorVM>>(repo.GetAuthors());
        }

        public IEnumerable<IAuthorVM> GetAuthors(IAuthorFilterVM filter)
        {
            return Mapper.Map<IEnumerable<IAuthorVM>>(repo.GetAuthors(Mapper.Map<IAuthorFilterEM>(filter)));
        }

        public IBookVM GetBook(int bookID)
        {
            return Mapper.Map<IBookVM>(repo.GetBook(bookID));
        }

        public IEnumerable<IBookVM> GetBooks()
        {
            return Mapper.Map<IEnumerable<IBookVM>>(repo.GetBooks());
        }

        public IEnumerable<IBookVM> GetBooks(IBookFilterVM filter)
        {
            return Mapper.Map<IEnumerable<IBookVM>>(repo.GetBooks(Mapper.Map<IBookFilterEM>(filter)));
        }

        public bool UpdateAuthor(IAuthorVM author)
        {
            return repo.UpdateAuthor(Mapper.Map<IAuthorEM>(author));
        }

        public bool UpdateBook(IBookVM book)
        {
            return repo.UpdateBook(Mapper.Map<IBookEM>(book));
        }
    }
}
