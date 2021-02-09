using System;
using System.Collections.Generic;
using System.Text;

namespace EncoraCodingExercise.Model.ViewModels
{
    public class UserResponseViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public int YearBuilt { get; set; }
        public decimal ListPrice { get; set; }

        public decimal MontlyRent { get; set; }

        public decimal GrossYield { get; set; }
    }
}
