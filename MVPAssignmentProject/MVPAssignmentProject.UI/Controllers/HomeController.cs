using MVPAssignmentProject.Infrastructure.DatabaseContext;
using MVPAssignmentProject.Infrastructure.Services;
using MVPAssignmentProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVPAssignmentProject.Domain.Dto;
using System.Threading.Tasks;

namespace MVPAssignmentProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearch _search;

        public HomeController()
        {
            this._search = new SearchServices(new MVPAssignmentDbContext());
        }

        /// <summary>    
        ///This action call store procedure from database.
        /// </summary>   
        public async Task<ActionResult> Index()
        {
            PropertySearch model = new PropertySearch();
            model.PropertyTypeId = 0;
            model.PriceFrom = 0m;
            model.PriceTo = 0m;
            model.PropertyLocation = string.Empty;
            model.PropertySearchList =await _search.SearchAsync(model);
            return View(model);
        }

        [HttpPost]
        public async Task<PartialViewResult> ReportSearch(PropertySearch propertySearch)
        {
            propertySearch.PropertySearchList = await _search.SearchAsync(propertySearch);
            return PartialView("_ParameterWiseSearch", propertySearch);
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