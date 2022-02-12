using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LAB.Models
{
    public class Raw
    {
        public int Id { get; set; }
        [Required]
        public string NameOfRaw { get; set; }
        [Required]
       
        public Measurement Measurement { get; set; }
        public int Sum { get; set; }
        [Required]
        public int? Quantity { get; set; }

        
        
    }
}
