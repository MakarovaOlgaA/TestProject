using BookCataloque.Bootstrap.DependencyResolving;
using BookCataloque.Infrastructure.Resolving;
using System.Web;
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
                if (filterContext.Exception is HttpException)
                {
                    ViewBag.StatusCode = ((HttpException)filterContext.Exception).GetHttpCode();
                }

                ViewBag.Message = filterContext.Exception.Message;
                filterContext.Result = View("Error");

                filterContext.ExceptionHandled = true;
            }
        }
    }
}