using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVPAssignmentProject.Domain.Model
{
    public class PropertyDetails
    {
        [Key]
        public int PropertyDetailId { get; set; }
        public int BrokerId { get; set; }
        public int PropertypeId { get; set; }
        public string Description { get; set; }
        public byte[] PropertyImage { get; set; }
        public int PropertyStatus { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Required]
        public decimal Price { get; set; }

        public string Location { get; set; }

        [NotMapped]
        public HttpPostedFileBase PropertyImageFile { get; set; }



    }
}
