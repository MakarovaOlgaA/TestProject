using BookCataloque.EntityModel;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Data
{ 
    public interface IBookRepository
    {
        void AddBook(BookEM book);

        BookEM GetBook(int bookID);

        IEnumerable<BookEM> GetBooks();

        IEnumerable<BookEM> GetBooks(BookFilterEM filter, int pageNumber, int pageSize, out int total, string sortColumn = null, bool descendingSortOrder = false);

        bool UpdateBook(BookEM book);

        bool DeleteBook(int bookID);
    }
}
