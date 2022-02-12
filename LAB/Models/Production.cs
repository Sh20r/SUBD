using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB.Models
{
    public class Production
    {
        public int Id { get; set; }
        
        public FinishedProducts FinishedProducts { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        
        public Employee Employee { get; set; }
        
        


    }
}
