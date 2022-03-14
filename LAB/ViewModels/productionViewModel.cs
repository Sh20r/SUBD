using LAB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LAB.ViewModels
{
    public class productionViewModel
    {
        public SelectList FinProduct { get; set; }
        public SelectList Employee { get; set; }
        [Required]
        public int Quantity { get; set; }
        public IEnumerable<Ingredients> ingredients {get; set;}

        public int? selectedProd { get; set; }
        public int? selectedEmp { get; set; }
        public string errorText { get; set; }
    }
}
