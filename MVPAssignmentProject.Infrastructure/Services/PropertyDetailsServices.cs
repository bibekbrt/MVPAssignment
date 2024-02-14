using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVPAssignmentProject.Domain.Model;
using MVPAssignmentProject.Infrastructure.DatabaseContext;

namespace MVPAssignmentProject.Infrastructure.Services
{
    public class PropertyDetailsServices:IPropertyDetails
    {
        private MVPAssignmentDbContext _dbContext;

        public PropertyDetailsServices(MVPAssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PropertyDetails>> GetAll()
        {
            return await _dbContext.PropertyDetails.ToListAsync();
        }

        public async Task<PropertyDetails> GetById(int id)
        {
            var obj = await _dbContext.PropertyDetails.FindAsync(id);
            return obj;
        }

        public Task<int> Insert(PropertyDetails entity)
        {
            _dbContext.PropertyDetails.Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(PropertyDetails entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(PropertyDetails entity)
        {
            PropertyDetails propertyDetails = await _dbContext.PropertyDetails.FindAsync(entity.PropertyDetailId);
            _dbContext.PropertyDetails.Remove(propertyDetails);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<PropertyDetails>> GetAllByBrokerId(int brokerId)
        {
            return await _dbContext.PropertyDetails.Where(x => x.BrokerId == brokerId).ToListAsync();
        }
    }
}
