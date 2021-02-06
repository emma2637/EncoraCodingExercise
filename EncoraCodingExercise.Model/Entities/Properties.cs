using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EncoraCodingExercise.Model.Entities
{
    public class Properties
    {
        [Required]
        public int Id { get; set; }

        public string Address { get; set; }

        public int YearBuilt { get; set; }

        public float ListPrice { get; set; }

        public float MontlyRent { get; set; }

        public int AccountNumber { get; set; }
    }
}
