using EncoraCodingExercise.Data;
using EncoraCodingExercise.Data.Contract.API;
using System;

namespace test
{
    class Program
    {


        public Program()
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IRequestHandlerRepository requestHandler = new RequestHandlerRepository();

            var  result =  requestHandler.GetPropertiesAsync();

            Console.Write(result);

        }
    }
}
