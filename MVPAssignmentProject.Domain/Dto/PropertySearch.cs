using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPAssignmentProject.Domain.Dto
{
    public class PropertySearch
    {
        public int PropertyId { get; set; }
        public int BrokerId { get; set; }
        public string PropertyDescription { get; set; }
        public string BrokerName  { get; set; }
        public string PropertyLocation { get; set; }
        public string BrokerAddress { get; set; }
        public string BrokerContact { get; set; }
        public decimal? PropertyPrice { get; set; }
        public string PropertyTypeName { get; set; }
        public byte[] PropertyImage { get; set; }
        public int PropertyTypeId { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }


        public List<PropertySearch> PropertySearchList { get; set; }

        public PropertySearch()
        {
           
            PropertySearchList=new List<PropertySearch>();
        }
    }

    
}
