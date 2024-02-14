using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MVPAssignmentProject.Domain.Model;
using MVPAssignmentProject.Infrastructure;
using MVPAssignmentProject.Infrastructure.DatabaseContext;
using MVPAssignmentProject.Infrastructure.Services;

namespace MVPAssignmentProject.UI.Controllers
{
    public class PropertyDetailsAPIController : ApiController
    {
        private readonly IPropertyDetails _iPropertyDetails;

        public PropertyDetailsAPIController()
        {
            this._iPropertyDetails = new PropertyDetailsServices(new MVPAssignmentDbContext());
        }


        // GET: api/PropertyDetailsAPI
        public async Task<IEnumerable<PropertyDetails>> GetPropertyDetails()
        {
            return await _iPropertyDetails.GetAll();
        }

        // GET: api/PropertyDetailsAPI/5
        [ResponseType(typeof(PropertyDetails))]
        public async Task<IHttpActionResult> GetPropertyDetails(int id)
        {
            PropertyDetails propertyDetails = await _iPropertyDetails.GetById(id);
            if (propertyDetails == null)
            {
                return NotFound();
            }

            return Ok(propertyDetails);
        }

        // PUT: api/PropertyDetailsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPropertyDetails(int id, PropertyDetails propertyDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            

            try
            {
                await _iPropertyDetails.Update(propertyDetails);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PropertyDetailsAPI
        [ResponseType(typeof(PropertyDetails))]
        public async Task<IHttpActionResult> PostPropertyDetails(PropertyDetails propertyDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _iPropertyDetails.Insert(propertyDetails);

            return CreatedAtRoute("DefaultApi", new { id = propertyDetails.PropertyDetailId }, propertyDetails);
        }

        // DELETE: api/PropertyDetailsAPI/5
        [ResponseType(typeof(PropertyDetails))]
        public async Task<IHttpActionResult> DeletePropertyDetails(int id)
        {
            PropertyDetails propertyDetails = await _iPropertyDetails.GetById(id);
            if (propertyDetails == null)
            {
                return NotFound();
            }

            await _iPropertyDetails.Delete(propertyDetails);
            return Ok(propertyDetails);
        }

        

      
    }
}