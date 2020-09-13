using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleSelectSkinRequestBuilder : RequestBuilder<SelectSkinDTORequest>
    {
        public ConsoleSelectSkinRequestBuilder WithId()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("SkinId: ");
                if (int.TryParse(Console.ReadLine(), out int skinId))
                {
                    Request.Id = skinId;
                    done = true;
                }
            }
            return this;
        }
    }
}
