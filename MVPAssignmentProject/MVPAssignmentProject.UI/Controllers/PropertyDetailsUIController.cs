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
using System.IO;

namespace MVPAssignmentProject.UI.Controllers
{
    /// <summary>    
    /// This controller is used to create new property details by individual broker
    /// Only after broker login, this controller is visible
    /// </summary>    
    [Authorize]
    public class PropertyDetailsUIController : Controller
    {
        private readonly IPropertyDetails _ipropertyDetails;
        private int brokerId = MVPAssignmentProject.UI.Helpers.GetCurrentLoginBrokerId();

        public PropertyDetailsUIController()
        {
            this._ipropertyDetails = new PropertyDetailsServices(new MVPAssignmentDbContext());
        }

        // GET: PropertyDetailsUI
        public async Task<ActionResult> Index()
        {
            
            return View(await _ipropertyDetails.GetAllByBrokerId(brokerId));
        }

        // GET: PropertyDetailsUI/Details/5
        public async Task<ActionResult> Details(int id)
        {

            PropertyDetails propertyDetails = await _ipropertyDetails.GetById(id);
            if (propertyDetails == null)
            {
                return HttpNotFound();
            }
            return View(propertyDetails);
        }

        // GET: PropertyDetailsUI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyDetailsUI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PropertyDetails propertyDetails)
        {

            if (propertyDetails != null && propertyDetails.PropertyImageFile != null)
            {
                byte[] fileData;
                using (var binaryReader = new BinaryReader(propertyDetails.PropertyImageFile.InputStream))
                {
                    fileData = binaryReader.ReadBytes(propertyDetails.PropertyImageFile.ContentLength);
                    propertyDetails.PropertyImage = fileData;
                }
                propertyDetails.CreatedDate=DateTime.Now;
                propertyDetails.UpdatedDate=DateTime.Now;
                propertyDetails.PropertyStatus = 1;
                propertyDetails.BrokerId = brokerId;
                await _ipropertyDetails.Insert(propertyDetails);
                return RedirectToAction("Index");
            }
            else
            {
                return View(propertyDetails);
            }
        }

        // GET: PropertyDetailsUI/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            PropertyDetails propertyDetails = await _ipropertyDetails.GetById(id);
            if (propertyDetails == null)
            {
                return HttpNotFound();
            }
            return View(propertyDetails);
        }

        // POST: PropertyDetailsUI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PropertyDetails propertyDetails)
        {
            if (propertyDetails != null && propertyDetails.PropertyImageFile != null)
            {
                byte[] fileData;
                using (var binaryReader = new BinaryReader(propertyDetails.PropertyImageFile.InputStream))
                {
                    fileData = binaryReader.ReadBytes(propertyDetails.PropertyImageFile.ContentLength);
                    propertyDetails.PropertyImage = fileData;
                }
            }
            propertyDetails.UpdatedDate=DateTime.Now;
            await _ipropertyDetails.Update(propertyDetails);
            return RedirectToAction("Index");

            
        }

        // GET: PropertyDetailsUI/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            PropertyDetails propertyDetails = await _ipropertyDetails.GetById(id);
            if (propertyDetails == null)
            {
                return HttpNotFound();
            }
            return View(propertyDetails);
        }

        // POST: PropertyDetailsUI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PropertyDetails propertyDetails = await _ipropertyDetails.GetById(id);
            await _ipropertyDetails.Delete(propertyDetails);
            return RedirectToAction("Index");
        }


    }
}
