using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleAddFoodEntryRequestBuilder : RequestBuilder<AddFoodEntryDTORequest>
    {
        public ConsoleAddFoodEntryRequestBuilder WithOFFId()
        {
            bool isOk = false;
            while (!isOk)
            {
                Console.Write("OpenFoodFact id:");
                if(int.TryParse(Console.ReadLine(), out int offDataId))
                {
                    Request.OFFDataId = offDataId;
                    isOk = true;
                }
            }
            return this;
        }
    }
}
