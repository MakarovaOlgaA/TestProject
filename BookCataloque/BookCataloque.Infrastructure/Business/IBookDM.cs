using BookCataloque.ViewModel;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Business
{
    public interface IBookDM
    {
        void AddBook(BookVM book);

        BookVM GetBook(int bookID);

        IEnumerable<BookVM> GetBooks(BookFilterVM filter, out int total, out int filtered);

        bool UpdateBook(BookVM book);

        bool DeleteBook(int bookID);
    }
}
