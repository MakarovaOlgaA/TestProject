using BookCataloque.Infrastructure.Business;
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

        // GET: Authors
        public ActionResult Index()
        {
            return View();
        }
    }
}