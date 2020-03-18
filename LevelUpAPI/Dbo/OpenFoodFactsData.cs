using LevelUpAPI.Dbo.OpenFoodFacts;
using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class OpenFoodFactsData : IObjectWithId
    {
        private const string ENERGY_100G_KEY = "energy_100g";
        private const string SODIUM_100G_KEY = "sodium_100g";
        private const string SALT_100G_KEY = "salt_100g";
        private const string FAT_100G_KEY = "fat_100g";
        private const string SATURATED_FAT_100G_KEY = "saturated-fat_100g";
        private const string PROTEINS_100G_KEY = "proteins_100g";
        private const string SUGARS_100_KEY = "sugars_100g";


        private bool TryGetFloat(ProductData productData, string key, out float value)
        {
            value = 0;
            if (productData.Nutriments.TryGetValue(key, out string valueStr))
            {
                valueStr = valueStr.Replace('.', ',');
                if (float.TryParse(valueStr, out value))
                    return true;
            }
            return false;
        }

        public OpenFoodFactsData()
        {

        }

        public OpenFoodFactsData(ProductData productData)
        {
            Code = productData.Code;
            Name = productData.GenericName;

            if (productData.Nutriments != null)
            {
                if (TryGetFloat(productData, ENERGY_100G_KEY, out float energy100g))
                {
                    Energy100g = energy100g;
                }

                if (TryGetFloat(productData, SODIUM_100G_KEY, out float sodium100g))
                {
                    Sodium100g = sodium100g;
                }

                if (TryGetFloat(productData, SALT_100G_KEY, out float salt100g))
                {
                    Salt100g = salt100g;
                }

                if (TryGetFloat(productData, FAT_100G_KEY, out float fat100g))
                {
                    Fat100g = fat100g;
                }

                if (TryGetFloat(productData, SATURATED_FAT_100G_KEY, out float saturatedFat100g))
                {
                    SaturatedFat100g = saturatedFat100g;
                }

                if (TryGetFloat(productData, PROTEINS_100G_KEY, out float proteins100g))
                {
                    Proteins100g = proteins100g;
                }

                if (TryGetFloat(productData, SUGARS_100_KEY, out float sugars100g))
                {
                    Sugars100g = sugars100g;
                }
            }
            
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double? Energy100g { get; set; }
        public double? Sodium100g { get; set; }
        public double? Salt100g { get; set; }
        public double? Fat100g { get; set; }
        public double? SaturatedFat100g { get; set; }
        public double? Proteins100g { get; set; }
        public double? Sugars100g { get; set; }
    }
}
