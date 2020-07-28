using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MassTransit;
using RabbitMQ.Client;

namespace Rembrandt.Web.Services
{
    public class RabbitMq
    {
        public async Task CreateBus()
        {
            var list = new List<int>() {5,4,3,4,4,3};

            foreach(var number in list)
            {
                string value = "";
                if(number % 3 == 0)
                    value += "Fizz";
                if(number % 5 == 0)
                    value += "Buzz";
                Console.WriteLine(String.IsNullOrWhiteSpace(value) ? number.ToString() : value);
            }
        }
    }
}