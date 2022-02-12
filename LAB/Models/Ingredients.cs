using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        
        public Raw Raw { get; set; }
        
        public FinishedProducts FinishedProducts { get; set; }
    }
}
