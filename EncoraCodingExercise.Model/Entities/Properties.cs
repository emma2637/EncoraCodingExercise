using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EncoraCodingExercise.Model.Entities
{
    public class Properties
    {
        [Required]
        public int Id { get; set; }

        public string Address { get; set; }

        public long YearBuilt { get; set; }

        public long ListPrice { get; set; }

        public long MontlyRent { get; set; }
        
        public decimal GrossYield { get; set; }

        public int AccountNumber { get; set; }
    }
}
