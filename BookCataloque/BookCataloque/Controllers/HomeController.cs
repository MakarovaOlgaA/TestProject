using System.Web.Mvc;

namespace BookCataloque.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var l = Factory.GetService<Infrastructure.Business.IBLCore>();
            var b = l.GetBook(1);
            return View();
        }
    }
}