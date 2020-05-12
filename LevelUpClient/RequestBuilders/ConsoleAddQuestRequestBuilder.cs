using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleAddQuestRequestBuilder : RequestBuilder<AddQuestRequest>
    {
        public ConsoleAddQuestRequestBuilder WithCategoryId()
        {
            Console.Write("Category ID: ");
            string categoryIdInput = Console.ReadLine();
            if (int.TryParse(categoryIdInput, out int categoryId))
                Request.CategoryId = categoryId;
            return this;
        }

        public ConsoleAddQuestRequestBuilder WithTypeId()
        {
            Console.Write("Type ID: ");
            string typeIdInput = Console.ReadLine();
            if (int.TryParse(typeIdInput, out int typeId))
                Request.TypeId = typeId;
            return this;
        }

        public ConsoleAddQuestRequestBuilder WithDatas()
        {
            Console.WriteLine("Datas: ");
            ConsoleKey finishKey = ConsoleKey.Escape;
            ConsoleKey inputKey;
            string key;
            string value;
            Request.Data = new Dictionary<string, string>();
            do
            {
                Console.WriteLine("Type " + finishKey.ToString() + " to finish data dict");
                inputKey = Console.ReadKey().Key;
                if (inputKey == finishKey)
                    break;
                Console.Write("Key: ");
                key = Console.ReadLine();
                Console.Write("Value: ");
                value = Console.ReadLine();

                if (!Request.Data.ContainsKey(key))
                    Request.Data.Add(key, value);
                else
                {
                    Console.WriteLine("Data was not inserted because " + key + " was already existing");
                }
            } while (true);
            return this;
        }
    }
}
