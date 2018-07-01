using System.Collections.Generic;

namespace BookCataloque.BL.Interfaces
{
    public interface IBLCore
    {
        void AddBook(IBookVM book);
        void AddAuthor(IAuthorVM author);

        IBookVM GetBook(int bookID);
        IEnumerable<IBookVM> GetBooks();
        IEnumerable<IBookVM> GetBooks(IBookFilterVM filter);

        IAuthorVM GetAuthor(int authorID);
        IEnumerable<IAuthorVM> GetAuthors();
        IEnumerable<IAuthorVM> GetAuthors(IAuthorFilterVM filter);

        bool UpdateBook(IBookVM book);
        bool UpdateAuthor(IAuthorVM author);

        bool DeleteBook(int bookID);
        bool DeleteAuthor(int authorID);
    }
}
