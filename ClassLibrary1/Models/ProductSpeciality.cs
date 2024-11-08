using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.core.Models
{
  public class ProductSpeciality
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
     public int ProductId { get; set; }
     public Speciality Caretria { get; set; }
     public Product Product { get; set; }    
 
    }
}
