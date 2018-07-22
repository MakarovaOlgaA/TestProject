using BookCataloque.ViewModel;
using System.Collections.Generic;

namespace BookCataloque.Infrastructure.Business
{
    public interface IBookDM
    {
        void AddBook(BookVM book);

        BookVM GetBook(int bookID);

        IEnumerable<BookVM> GetBooks(SearchInfoVM searchInfo, out FilteredInfoVM filteredInfo);
        IEnumerable<BookVM> GetBooks(BookFilterVM filter, SearchInfoVM searchInfo, out FilteredInfoVM filteredInfo);

        bool UpdateBook(BookVM book);

        bool DeleteBook(int bookID);
    }
}
