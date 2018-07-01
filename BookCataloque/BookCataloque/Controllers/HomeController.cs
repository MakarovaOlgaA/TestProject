using BookCataloque.BL.Interfaces;
using System.Web.Mvc;
using Unity.Attributes;

namespace BookCataloque.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBLCore bl;

        [InjectionConstructor]
        public HomeController(IBLCore bl)
        {
            this.bl = bl;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}