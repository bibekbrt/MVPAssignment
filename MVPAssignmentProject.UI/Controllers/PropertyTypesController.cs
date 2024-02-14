using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MVPAssignmentProject.Domain.Model;
using MVPAssignmentProject.Infrastructure;
using MVPAssignmentProject.Infrastructure.DatabaseContext;
using MVPAssignmentProject.Infrastructure.Services;


namespace MVPAssignmentProject.UI.Controllers
{
    public class PropertyTypesController : ApiController
    {
        private readonly IPropertyType _iPropertyType;

        public PropertyTypesController()
        {
            this._iPropertyType = new PropertyTypeService(new MVPAssignmentDbContext());
        }

        // GET: api/PropertyTypes
        public async Task<IEnumerable<PropertyTypes>> GetPropertyTypes()
        {
            return await this._iPropertyType.GetAll();
        }

        // GET: api/PropertyTypes/5
        [ResponseType(typeof(PropertyTypes))]
        public async Task<IHttpActionResult> GetPropertyTypes(int id)
        {
            PropertyTypes propertyTypes = await _iPropertyType.GetById(id);
            if (propertyTypes == null)
            {
                return NotFound();
            }

            return Ok(propertyTypes);
        }

        // PUT: api/PropertyTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPropertyTypes(int id, PropertyTypes propertyTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertyTypes.PropertyTypeId)
            {
                return BadRequest();
            }

            

            try
            {
               await _iPropertyType.Update(propertyTypes);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PropertyTypesExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PropertyTypes
        [ResponseType(typeof(PropertyTypes))]
        public async Task<IHttpActionResult> PostPropertyTypes(PropertyTypes propertyTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _iPropertyType.Insert(propertyTypes);

            return CreatedAtRoute("DefaultApi", new { id = propertyTypes.PropertyTypeId }, propertyTypes);
        }

        // DELETE: api/PropertyTypes/5
        [ResponseType(typeof(PropertyTypes))]
        public async Task<IHttpActionResult> DeletePropertyTypes(int id)
        {
            PropertyTypes propertyTypes = await _iPropertyType.GetById(id);
            if (propertyTypes == null)
            {
                return NotFound();
            }

            await _iPropertyType.Delete(propertyTypes);

            return Ok(propertyTypes);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PropertyTypesExists(int id)
        //{
        //    return _db.PropertyTypes.Count(e => e.PropertyTypeId == id) > 0;
        //}
    }
}