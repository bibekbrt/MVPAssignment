using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVPAssignmentProject.Domain.Model;
using MVPAssignmentProject.Infrastructure.DatabaseContext;
using MVPAssignmentProject.Infrastructure.Services;
using MVPAssignmentProject.Infrastructure;

namespace MVPAssignmentProject.UI.Controllers
{
    /// <summary>    
    /// This controller is used to create new property Type
    /// Only after broker login, this controller is visible
    /// </summary>   
    [Authorize]
    public class PropertyTypesUIController : Controller
    {
        private readonly IPropertyType _iPropertyType;

        public PropertyTypesUIController()
        {
            this._iPropertyType = new PropertyTypeService(new MVPAssignmentDbContext());
        }

        // GET: PropertyTypesUI
        public async Task<ActionResult> Index()
        {
            return View(await _iPropertyType.GetAll());
        }

        // GET: PropertyTypesUI/Details/5
        public async Task<ActionResult> Details(int id)
        {
           
            PropertyTypes propertyTypes = await _iPropertyType.GetById(id);
            if (propertyTypes == null)
            {
                return HttpNotFound();
            }
            return View(propertyTypes);
        }

        // GET: PropertyTypesUI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyTypesUI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PropertyTypes propertyTypes)
        {
            if (ModelState.IsValid)
            {
                
               await _iPropertyType.Insert(propertyTypes);
                return RedirectToAction("Index");
            }

            return View(propertyTypes);
        }

        // GET: PropertyTypesUI/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            

            PropertyTypes propertyTypes = await _iPropertyType.GetById(id);
            if (propertyTypes == null)
            {
                return HttpNotFound();
            }
            return View(propertyTypes);
        }

        // POST: PropertyTypesUI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PropertyTypes propertyTypes)
        {
            if (ModelState.IsValid)
            {
                _iPropertyType.Update(propertyTypes);
                return RedirectToAction("Index");
            }
            return View(propertyTypes);
        }

        // GET: PropertyTypesUI/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            PropertyTypes propertyTypes = await _iPropertyType.GetById(id);
            if (propertyTypes == null)
            {
                return HttpNotFound();
            }
            return View(propertyTypes);
        }

        // POST: PropertyTypesUI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PropertyTypes propertyTypes = await _iPropertyType.GetById(id);

            await _iPropertyType.Delete(propertyTypes);
            return RedirectToAction("Index");
        }

       
    }
}
