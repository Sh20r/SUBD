using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB.Models
{
    public class Raw
    {
        public Raw()
        {
            Ingredients = new HashSet<Ingredients>();
        }
        public int Id { get; set; }
        [Required]
        public string NameOfRaw { get; set; }
        [Required]

        public Measurement Measurement { get; set; }
        public int MeasurementId { get; set; }
        public int Sum { get; set; }
        [Required]
        public int? Quantity { get; set; }

       public IEnumerable<Ingredients> Ingredients { get; set; }
        
       public IEnumerable<PurchaseRaw> PurchaseRaws { get; set; }
       
    }
}
