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
using System.IO;

namespace MVPAssignmentProject.UI.Controllers
{
    public class PropertyDetailsController : Controller
    {
        private MVPAssignmentDbContext db = new MVPAssignmentDbContext();

        // GET: PropertyDetails
        public async Task<ActionResult> Index()
        {
            return View(await db.PropertyDetails.ToListAsync());
        }

        // GET: PropertyDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyDetails propertyDetails = await db.PropertyDetails.FindAsync(id);
            if (propertyDetails == null)
            {
                return HttpNotFound();
            }
            return View(propertyDetails);
        }

        // GET: PropertyDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyDetails/Create
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
                    db.PropertyDetails.Add(propertyDetails);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(propertyDetails);
                }
            
        }

        // GET: PropertyDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyDetails propertyDetails = await db.PropertyDetails.FindAsync(id);
            if (propertyDetails == null)
            {
                return HttpNotFound();
            }
            return View(propertyDetails);
        }

        // POST: PropertyDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PropertyDetails propertyDetails)
        {
            if (ModelState.IsValid)
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

                db.Entry(propertyDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(propertyDetails);
        }

        // GET: PropertyDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyDetails propertyDetails = await db.PropertyDetails.FindAsync(id);
            if (propertyDetails == null)
            {
                return HttpNotFound();
            }
            return View(propertyDetails);
        }

        // POST: PropertyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PropertyDetails propertyDetails = await db.PropertyDetails.FindAsync(id);
            db.PropertyDetails.Remove(propertyDetails);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
