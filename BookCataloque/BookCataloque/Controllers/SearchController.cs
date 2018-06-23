using System.Web.Mvc;
using BookCataloque.BL.Interfaces;

namespace BookCataloque.Controllers
{
    public class SearchController : Controller
    {
        private ISearcher searcher;

        public SearchController(ISearcher searcher)
        {
            this.searcher = searcher;
        }

        //public JsonResult ApplyFilter()
        //{ 
        //}
    }
}