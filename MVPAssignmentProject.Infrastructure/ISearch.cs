using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVPAssignmentProject.Domain.Dto;

namespace MVPAssignmentProject.Infrastructure
{
    public interface ISearch
    {
        Task<List<PropertySearch>> SearchAsync(PropertySearch propertySearch);
    }
}
