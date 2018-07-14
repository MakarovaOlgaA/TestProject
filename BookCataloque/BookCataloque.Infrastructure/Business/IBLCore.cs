using System.Collections.Generic;
using BookCataloque.Infrastructure.Business.Models;

namespace BookCataloque.Infrastructure.Business
{
    public interface IBLCore
    {
        void AddBook(BookVM book);
        void AddAuthor(AuthorVM author);

        BookVM GetBook(int bookID);
        IEnumerable<BookVM> GetBooks();
        IEnumerable<BookVM> GetBooks(BookFilterVM filter);

        AuthorVM GetAuthor(int authorID);
        IEnumerable<AuthorVM> GetAuthors();
        IEnumerable<AuthorVM> GetAuthors(AuthorFilterVM filter);

        bool UpdateBook(BookVM book);
        bool UpdateAuthor(AuthorVM author);

        bool DeleteBook(int bookID);
        bool DeleteAuthor(int authorID);
    }
}
