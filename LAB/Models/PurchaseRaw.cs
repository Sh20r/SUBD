using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LAB.Models
{
    public class PurchaseRaw
    {
        public int Id { get; set; }      
        public int Quantity { get; set; }      
        public int Sum { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Raw Raw { get; set; }
        public int RawId { get; set; }
    }
}
