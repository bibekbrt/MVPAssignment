using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVPAssignmentProject.Domain.Dto;
using MVPAssignmentProject.Infrastructure.DatabaseContext;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace MVPAssignmentProject.Infrastructure.Services
{
    public class SearchServices:ISearch
    {
        private readonly MVPAssignmentDbContext _dbContext;

        public SearchServices(MVPAssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<PropertySearch>> SearchAsync(PropertySearch propertySearch)
        {
            var locationParam = new SqlParameter { ParameterName = "@Location", Value = propertySearch.PropertyLocation==null?string.Empty:propertySearch.PropertyLocation };
            var priceFromParam = new SqlParameter { ParameterName = "@PriceFrom", Value = propertySearch.PriceFrom.HasValue?propertySearch.PriceFrom:0m };
            var priceToParam = new SqlParameter { ParameterName = "@PriceTo", Value = propertySearch.PriceTo.HasValue ? propertySearch.PriceTo : 0m };
            var propertyTypeParam = new SqlParameter { ParameterName = "@PropertyType", Value = propertySearch.PropertyTypeId };
            return await _dbContext.Database.SqlQuery<PropertySearch>("Sp_SearchProperties @Location,@PriceFrom,@PriceTo,@PropertyType", locationParam,priceFromParam,priceToParam,propertyTypeParam).ToListAsync();
           
        }
    }
}
