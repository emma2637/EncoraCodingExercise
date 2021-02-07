using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Web.Infraestructure
{
    public static class ApiPaths
    {
        public static string GetAllUserProperties(string baseUri)
        {
            return $"{baseUri}/properties";
        }

        public static string GetPropertiesById(string baseUri, int id)
        {
            return $"{baseUri}/properties/{id}";
        }
        public static string CreateNewProperty(string baseUri)
        {
            return $"{baseUri}/properties/create";
        }

        public static string UpdateProperty(string baseUri)
        {
            return $"{baseUri}/properties/update";
        }
    }
}
