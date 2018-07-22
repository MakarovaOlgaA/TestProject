using BookCataloque.Infrastructure.Business;
using System.Web.Mvc;
using BookCataloque.ViewModel;

namespace BookCataloque.Controllers
{
    public class BooksController : BaseController
    {
        public ActionResult Index()
        {
            SearchInfoVM searchInfo = new SearchInfoVM()
            {
                CurrentPage = 1,
                PageSize = 100,
                OrderingInfo = new OrderingInfoVM { ColumnName = "Title" }
            };

            var books = Factory.GetService<IBookDM>().GetBooks(searchInfo, out FilteredInfoVM filteredInfo);

            return View(books);
        }
    }
}