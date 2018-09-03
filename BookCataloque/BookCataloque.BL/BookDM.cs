using BookCataloque.EntityModel;
using BookCataloque.Infrastructure.Business;
using BookCataloque.Infrastructure.Data;
using BookCataloque.Infrastructure.Resolving;
using BookCataloque.ViewModel;
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

        public IEnumerable<BookVM> GetBooks(BookFilterVM filter, out int total, out int filtered)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            IEnumerable<BookEM> result;

            if (filter.Order.Count != 0)
            {
                string columName = filter.Columns[filter.Order.First().Column].Name;
                bool descOrder = filter.Order.First().Dir.ToUpper() == "DESC";

                result = repo.GetBooks(entityLocator.ConvertTo<BookFilterEM>(filter), filter.Length, filter.Start, out total, columName, descOrder);
            }
            else
            {
                result = repo.GetBooks(entityLocator.ConvertTo<BookFilterEM>(filter), filter.Length, filter.Start, out total);
            }

            filtered = result.Count();

            return entityLocator.ConvertTo<IEnumerable<BookVM>>(result);
        }

        public bool UpdateBook(BookVM book)
        {
            var repo = serviceLocator.GetService<IBookRepository>();
            return repo.UpdateBook(entityLocator.ConvertTo<BookEM>(book));
        }
    }
}
