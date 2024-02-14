using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVPAssignmentProject.Domain.Model;

namespace MVPAssignmentProject.UI.Controllers
{
    public class PropertyTypeController : Controller
    {


        // GET: PropertyType
        public async Task<ActionResult> Index()
        {
            IEnumerable<PropertyTypes> properties = new List<PropertyTypes>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44348/");

                HttpResponseMessage response = await httpClient.GetAsync("api/PropertyTypes");


                if (response.IsSuccessStatusCode)
                {

                    var data = await response.Content.ReadAsAsync<IList<PropertyTypes>>();

                    return View(data);
                }

                else
                {
                    // Handle error response
                    // For example, return a specific view for error handling
                    return View("Error");
                }
            }




        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PropertyTypes types)
        {

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44348/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/PropertyTypes", types);
                if (response.IsSuccessStatusCode)
                {
                    // Handle successful response
                    // For example, read response content
                    string responseData = await response.Content.ReadAsStringAsync();
                    return Content(responseData);
                }
                else
                {
                    // Handle unsuccessful response
                    // For example, return an error view
                    return View("Error");
                }


            }
        }



    }
}