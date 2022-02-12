using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LAB.Models
{
    public class FinishedProducts
    {
        public int Id { get; set; }
       
        public Measurement Measurement { get; set; }
        public int Sum { get; set; }
        public int Quantity { get; set; }

        

    }
}
