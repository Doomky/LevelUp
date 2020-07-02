using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleAddPARequestBuilder : RequestBuilder<AddPADTORequest>
    {
        public ConsoleAddPARequestBuilder WithName()
        {
            Console.Write("Name:");
            Request.Name = Console.ReadLine();
            return this;
        }

        public ConsoleAddPARequestBuilder WithCalPerKgPerHour()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("Number of cal/kg/hour: ");
                if (double.TryParse(Console.ReadLine(), out double calPerKgPerHour))
                {
                    Request.CalPerKgPerHour = calPerKgPerHour;
                    done = true;
                }
            }
            return this;
        }
    }
}
