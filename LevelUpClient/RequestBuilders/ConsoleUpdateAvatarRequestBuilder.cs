using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleUpdateAvatarRequestBuilder : RequestBuilder<UpdateAvatarDTORequest>
    {
        public ConsoleUpdateAvatarRequestBuilder WithNewSize()
        {
            bool done = false;
            while (!done)
            {
                Console.Write("New Size: ");
                if (int.TryParse(Console.ReadLine(), out int NewSize))
                {
                    Request.NewSize = NewSize;
                    done = true;
                }
            }
            return this;
        }
    }
}
