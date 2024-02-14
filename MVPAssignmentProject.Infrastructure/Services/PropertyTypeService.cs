using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVPAssignmentProject.Domain.Model;
using MVPAssignmentProject.Infrastructure;
using MVPAssignmentProject.Infrastructure.DatabaseContext;

namespace MVPAssignmentProject.Infrastructure.Services
{
    public class PropertyTypeService : IPropertyType
    {
        private readonly MVPAssignmentDbContext _dbContext;

        public PropertyTypeService(MVPAssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<PropertyTypes>> GetAll()
        {
            return await _dbContext.PropertyTypes.ToListAsync();
        }

        public async Task<PropertyTypes> GetById(int id)
        {
            var propertyType = await _dbContext.PropertyTypes.FindAsync(id);
            return propertyType;
        }

        public async Task<int> Insert(PropertyTypes entity)
        {
            _dbContext.PropertyTypes.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(PropertyTypes entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
           return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(PropertyTypes entity)
        {
            PropertyTypes propertyTypes = await _dbContext.PropertyTypes.FindAsync(entity.PropertyTypeId);
            _dbContext.PropertyTypes.Remove(propertyTypes);
            return await _dbContext.SaveChangesAsync();


        }
    }
}
