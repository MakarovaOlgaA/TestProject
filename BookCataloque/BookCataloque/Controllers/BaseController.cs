using BookCataloque.Bootstrap.DependencyResolving;
using BookCataloque.Infrastructure.Resolving;
using System.Web.Mvc;

namespace BookCataloque.Controllers
{
    public class BaseController : Controller
    {
        private readonly IServiceLocator serviceLocator = UnitySetup.CreateFactory();

        protected IServiceLocator Factory
        {
            get
            {
                return serviceLocator;
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = Error(filterContext.Exception.Message);
                filterContext.ExceptionHandled = true;
            }
        }

        public ActionResult Error(string errorMessage, int? statusCode = null)
        {
            ViewBag.StatusCode = statusCode;
            return View("Error", model: errorMessage);
        }
    }
}