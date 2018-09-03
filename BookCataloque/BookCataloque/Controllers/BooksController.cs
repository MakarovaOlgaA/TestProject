using BookCataloque.Infrastructure.Business;
using System.Web.Mvc;
using BookCataloque.ViewModel;

namespace BookCataloque.Controllers
{
    public class BooksController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["Authors"] = Factory.GetService<IAuthorDM>().GetAuthors();
            return View();
        }

        public JsonResult GetBook(int id)
        {
            var book = Factory.GetService<IBookDM>().GetBook(id);

            return Json(new { success = book != null, data = book });
        }

        public JsonResult GetBooks(BookFilterVM filter)
        {
            var books = Factory.GetService<IBookDM>().GetBooks(filter, out int total, out int filtered);

            return Json(new { draw = filter.Draw, recordsFiltered = filtered, recordsTotal = total, data = books });
        }

        public JsonResult Delete(int id)
        {
            bool deleted = Factory.GetService<IBookDM>().DeleteBook(id);

            return Json(new { success = deleted });
        }

        public JsonResult Add(BookVM book)
        {
            Factory.GetService<IBookDM>().AddBook(book);
            return Json(new { success = true });
        }

        public JsonResult Update(BookVM book)
        {
            bool updated = Factory.GetService<IBookDM>().UpdateBook(book);
            return Json(new { success = updated });
        }
    }
}