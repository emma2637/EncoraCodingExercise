using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Web.Models
{
    public class ResponseViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string YearBuilt { get; set; }
        public string ListPrice { get; set; }

        public string MontlyRent { get; set; }

        public string GrossYield { get; set; }
    }
}
