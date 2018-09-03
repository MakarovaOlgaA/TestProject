using BookCataloque.Infrastructure.Business;
using BookCataloque.ViewModel;
using System.Web.Mvc;

namespace BookCataloque.Controllers
{
    public class AuthorsController : BaseController
    {
        public ActionResult Details(string firstName, string lastName)
        {
            var author = Factory.GetService<IAuthorDM>().GetAuthor(firstName, lastName);

            if (author == null)
            {
                string message = string.Format("{0} {1} was not found in the cataloque of authors.", firstName, lastName);
                return RedirectToAction("Error", "Base", new { errorMessage = message });
            }

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Delete(int id)
        {
            bool deleted = Factory.GetService<IAuthorDM>().DeleteAuthor(id);

            return Json(new { success = deleted });
        }

        public JsonResult Add(AuthorVM author)
        {
            Factory.GetService<IAuthorDM>().AddAuthor(author);
            return Json(new { success = true });
        }

        public JsonResult Update(AuthorVM author)
        {
            bool updated = Factory.GetService<IAuthorDM>().UpdateAuthor(author);
            return Json(new { success = updated });
        }
    }
}