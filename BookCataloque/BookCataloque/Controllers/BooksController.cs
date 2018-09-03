using BookCataloque.Infrastructure.Business;
using System.Web.Mvc;
using BookCataloque.ViewModel;

namespace BookCataloque.Controllers
{
    public class BooksController : BaseController
    {
        public ActionResult Index()
        {
            return View();
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
    }
}