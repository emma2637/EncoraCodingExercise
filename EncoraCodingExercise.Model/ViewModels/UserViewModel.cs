using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Model.ViewModels
{
    public class UserViewModel
    {
        public string Address { get; set; }

        public int YearBuilt { get; set; }
        public decimal ListPrice { get; set; }

        public decimal MontlyRent { get; set; }

    }
}
