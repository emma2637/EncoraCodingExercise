using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Model.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }

        public string Address { get; set; }

        public string YearBuilt { get; set; }
        public string ListPrice { get; set; }

        public string MontlyRent { get; set; }

        public string GrossYield { get; set; }

    }
}
