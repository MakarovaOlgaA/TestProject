using BookCataloque.Infrastructure.Business;
using System.Web.Mvc;

namespace BookCataloque.Controllers
{
    public class BooksController : BaseController
    {
        public ActionResult Index()
        {
            var books = Factory.GetService<IBLCore>().GetBooks();
            //var b = l.GetBook(1);
            return View(books);
        }
    }
}