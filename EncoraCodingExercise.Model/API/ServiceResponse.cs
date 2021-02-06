using System;
using System.Collections.Generic;
using System.Text;

namespace EncoraCodingExercise.Model.API
{
    public class ServiceResponse<T> //<T> type of data we want to send back
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;
    }
}
