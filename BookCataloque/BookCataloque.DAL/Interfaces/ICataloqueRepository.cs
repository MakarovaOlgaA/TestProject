using System.Collections.Generic;

namespace BookCataloque.DAL.Interfaces
{
    public interface ICataloqueRepository
    {
        void AddBook(IBookEM book);
        void AddAuthor(IAuthorEM author);

        IBookEM GetBook(int bookID);
        IEnumerable<IBookEM> GetBooks();
        IEnumerable<IBookEM> GetBooks(IBookFilterEM filter);

        IAuthorEM GetAuthor(int authorID);
        IEnumerable<IAuthorEM> GetAuthors();
        IEnumerable<IAuthorEM> GetAuthors(IAuthorFilterEM filter);

        bool UpdateBook(IBookEM book);
        bool UpdateAuthor(IAuthorEM author);

        bool DeleteBook(int bookID);
        bool DeleteAuthor(int authorID);
    }
}
