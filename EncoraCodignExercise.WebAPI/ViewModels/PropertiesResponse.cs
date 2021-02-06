using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncoraCodingExercise.WebAPI.ViewModels
{
    public class PropertiesResponse
    {
        public int AccountNumber { get; set; }

        public string Address { get; set; }

        public int YearBuilt { get; set; }

        public int MontlyRent { get; set; }

        public double GrossYield { get; set; }

    }
}
