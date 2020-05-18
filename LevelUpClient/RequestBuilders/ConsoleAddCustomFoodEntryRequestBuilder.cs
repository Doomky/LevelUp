using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestBuilders
{
    public class ConsoleAddCustomFoodEntryRequestBuilder : RequestBuilder<AddCustomFoodEntryRequest>
    {
        public ConsoleAddCustomFoodEntryRequestBuilder WithUserId()
        {
            Console.Write("User Id: ");
            bool isOk = false;
            while (!isOk)
            {
                if (int.TryParse(Console.ReadLine(), out int userId))
                {
                    Request.UserId = userId;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithName()
        {
            Console.Write("Name: ");
            Request.Name = Console.ReadLine();
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithEnergy100g()
        {
            Console.Write("Energy 100g: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double energy100g))
                {
                    Request.Energy100g = energy100g;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithSodium100g()
        {
            Console.Write("Sodium 100g: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double sodium100g))
                {
                    Request.Sodium100g = sodium100g;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithSalt100g()
        {
            Console.Write("Salt 100g: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double salt100g))
                {
                    Request.Salt100g = salt100g;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithFat100g()
        {
            Console.Write("Fat 100g: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double fat100g))
                {
                    Request.Fat100g = fat100g;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithSaturatedFat100g()
        {
            Console.Write("Saturated Fat 100g: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double saturatedFat100g))
                {
                    Request.SaturatedFat100g  = saturatedFat100g;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithProteins100g()
        {
            Console.Write("Proteins 100g: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double proteins100g))
                {
                    Request.Proteins100g = proteins100g;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithSugars100g()
        {
            Console.Write("Sugars 100g: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double sugars100g))
                {
                    Request.Sugars100g = sugars100g;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithEnergyServing()
        {
            Console.Write("Energy Serving: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double energyServing))
                {
                    Request.Energy100g = energyServing;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithSodiumServing()
        {
            Console.Write("Sodium Serving: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double sodiumServing))
                {
                    Request.SodiumServing = sodiumServing;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithSaltServing()
        {
            Console.Write("Salt Serving: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double saltServing))
                {
                    Request.SaltServing = saltServing;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithFatServing()
        {
            Console.Write("Fat Serving: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double fatServing))
                {
                    Request.FatServing = fatServing;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithSaturatedFatServing()
        {
            Console.Write("Saturated Fat Serving: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double saturatedFatServing))
                {
                    Request.SaturatedFatServing  = saturatedFatServing;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithProteinsServing()
        {
            Console.Write("Proteins Serving: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double proteins100g))
                {
                    Request.Proteins100g = proteins100g;
                    isOk = true;
                }
            }
            return this;
        }

        public ConsoleAddCustomFoodEntryRequestBuilder WithSugarsServing()
        {
            Console.Write("Sugars Serving: ");
            bool isOk = false;
            while (!isOk)
            {
                if (double.TryParse(Console.ReadLine(), out double sugars100g))
                {
                    Request.Sugars100g = sugars100g;
                    isOk = true;
                }
            }
            return this;
        }
    }
}
