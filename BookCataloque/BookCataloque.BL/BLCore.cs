using System.Collections.Generic;
using BookCataloque.Infrastructure.Business;
using BookCataloque.Infrastructure.Business.Models;
using BookCataloque.Infrastructure.Resolving;
using BookCataloque.Infrastructure.Data.Models;
using BookCataloque.Infrastructure.Data;

namespace BookCataloque.BL
{
    public class BLCore : IBLCore
    {
        private IServiceLocator serviceLocator;
        private IEntityLocator entityLocator;

        public BLCore(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
            this.entityLocator = serviceLocator.GetService<IEntityLocator>();
        }

        public void AddAuthor(AuthorVM author)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            repo.AddAuthor(entityLocator.ConvertTo<AuthorEM>(author));
        }

        public void AddBook(BookVM book)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            repo.AddBook(entityLocator.ConvertTo<BookEM>(book));
        }

        public bool DeleteAuthor(int authorID)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            return repo.DeleteAuthor(authorID);
        }

        public bool DeleteBook(int bookID)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            return repo.DeleteBook(bookID);
        }

        public AuthorVM GetAuthor(int authorID)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            return entityLocator.ConvertTo<AuthorVM>(repo.GetAuthor(authorID));
        }

        public IEnumerable<AuthorVM> GetAuthors()
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            return entityLocator.ConvertTo<IEnumerable<AuthorVM>>(repo.GetAuthors());
        }

        public IEnumerable<AuthorVM> GetAuthors(AuthorFilterVM filter)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            var authors = repo.GetAuthors(entityLocator.ConvertTo<AuthorFilterEM>(filter));
            return entityLocator.ConvertTo<IEnumerable<AuthorVM>>(authors);
        }

        public BookVM GetBook(int bookID)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            return entityLocator.ConvertTo<BookVM>(repo.GetBook(bookID));
        }

        public IEnumerable<BookVM> GetBooks()
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            return entityLocator.ConvertTo<IEnumerable<BookVM>>(repo.GetBooks());
        }

        public IEnumerable<BookVM> GetBooks(BookFilterVM filter)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            var books = repo.GetBooks(entityLocator.ConvertTo<BookFilterEM>(filter));
            return entityLocator.ConvertTo<IEnumerable<BookVM>>(books);
        }

        public bool UpdateAuthor(AuthorVM author)
        {
            var repo = serviceLocator.GetService<IAuthorRepository>();
            return repo.UpdateAuthor(entityLocator.ConvertTo<AuthorEM>(author));
        }

        public bool UpdateBook(BookVM book)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            return repo.UpdateBook(entityLocator.ConvertTo<BookEM>(book));
        }
    }
}
