using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EncoraCodingExercise.Model.Entities
{
    public class Properties
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Address { get; set; }

        public int YearBuilt { get; set; }

        public decimal ListPrice { get; set; }

        public decimal MontlyRent { get; set; }

        public decimal GrossYield { get; set; }
        public int AccountNumber { get; set; }
    }
}
