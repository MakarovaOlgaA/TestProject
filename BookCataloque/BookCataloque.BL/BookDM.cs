using BookCataloque.EntityModel;
using BookCataloque.Infrastructure.Business;
using BookCataloque.Infrastructure.Data;
using BookCataloque.Infrastructure.Resolving;
using BookCataloque.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookCataloque.BL
{
    public class BookDM: BLCore, IBookDM
    {
        public BookDM(IServiceLocator serviceLocator): base(serviceLocator)
        {
        }

        public void AddBook(BookVM book)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            repo.AddBook(entityLocator.ConvertTo<BookEM>(book));
        }

        public bool DeleteBook(int bookID)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            return repo.DeleteBook(bookID);
        }


        public BookVM GetBook(int bookID)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            return entityLocator.ConvertTo<BookVM>(repo.GetBook(bookID));
        }

        public IEnumerable<BookVM> GetBooks(SearchInfoVM searchInfo, out FilteredInfoVM filteredInfo)
        {
            var repo = serviceLocator.GetService<IBookRepository>();

            var result = repo.GetBooks(searchInfo.PageSize, searchInfo.CurrentPage, out int total, 
                searchInfo.OrderingInfo.ColumnName, searchInfo.OrderingInfo.DescendingOrder);

            int numPages = (int)Math.Ceiling((double)total / searchInfo.PageSize);
            filteredInfo = new FilteredInfoVM() { Total = total, Filtered = result.Count(), NumberOfPages = numPages };

            return entityLocator.ConvertTo<IEnumerable<BookVM>>(result);
        }

        public IEnumerable<BookVM> GetBooks(BookFilterVM filter, SearchInfoVM searchInfo, out FilteredInfoVM filteredInfo)
        {
            var repo = serviceLocator.GetService<IBookRepository>();

            var result = repo.GetBooks(entityLocator.ConvertTo<BookFilterEM>(filter), searchInfo.PageSize, searchInfo.CurrentPage,
                out int total, searchInfo.OrderingInfo.ColumnName, searchInfo.OrderingInfo.DescendingOrder);

            int numPages = (int)Math.Ceiling((double)total / searchInfo.PageSize);
            filteredInfo = new FilteredInfoVM() { Total = total, Filtered = result.Count(), NumberOfPages = numPages };

            return entityLocator.ConvertTo<IEnumerable<BookVM>>(result);
        }

        public bool UpdateBook(BookVM book)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            return repo.UpdateBook(entityLocator.ConvertTo<BookEM>(book));
        }
    }
}
