using BookCataloque.Infrastructure.Data.Models;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Data
{ 
    public interface IBookRepository
    {
        void AddBook(BookEM book);

        BookEM GetBook(int bookID);
        IEnumerable<BookEM> GetBooks();
        IEnumerable<BookEM> GetBooks(BookFilterEM filter);

        bool UpdateBook(BookEM book);

        bool DeleteBook(int bookID);
    }
}
