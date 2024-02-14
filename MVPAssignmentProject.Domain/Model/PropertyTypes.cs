using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace MVPAssignmentProject.Domain.Model
{
    public class PropertyTypes
    {
        [Key]
        public int PropertyTypeId { get; set; }
        [DisplayName("Property Type Name")]
        [Required(ErrorMessage = "Please enter property name")]
        public string TypeName { get; set; }
        public bool? DisplayStatus { get; set; }
    }

}
