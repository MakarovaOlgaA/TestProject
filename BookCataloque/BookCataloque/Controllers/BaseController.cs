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
    }
}