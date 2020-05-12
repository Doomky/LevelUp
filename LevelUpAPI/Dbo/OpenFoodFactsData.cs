using LevelUpAPI.Dbo.OpenFoodFacts;
using System;
using System.Collections.Generic;

namespace LevelUpAPI.Dbo
{
    public class OpenFoodFactsData : IObjectWithId
    {
        // 100g
        private const string ENERGY_100G_KEY = "energy_100g";
        private const string SODIUM_100G_KEY = "sodium_100g";
        private const string SALT_100G_KEY = "salt_100g";
        private const string FAT_100G_KEY = "fat_100g";
        private const string SATURATED_FAT_100G_KEY = "saturated-fat_100g";
        private const string PROTEINS_100G_KEY = "proteins_100g";
        private const string SUGARS_100_KEY = "sugars_100g";
        
        // Serving
        private const string ENERGY_SERVING_KEY = "energy_serving";
        private const string SODIUM_SERVING_KEY = "sodium_serving";
        private const string SALT_SERVING_KEY = "salt_serving";
        private const string FAT_SERVING_KEY = "fat_serving";
        private const string SATURATED_FAT_SERVING_KEY = "saturated-fat_serving";
        private const string PROTEINS_SERVING_KEY = "proteins_serving";
        private const string SUGARS_SERVING_KEY = "sugars_serving";

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

        private float KjToKcal(float kj)
        {
            return kj / 4.184f;
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
                    Energy100g = energy100g;

                if (TryGetFloat(productData, SODIUM_100G_KEY, out float sodium100g))
                    Sodium100g = sodium100g;

                if (TryGetFloat(productData, SALT_100G_KEY, out float salt100g))
                    Salt100g = salt100g;

                if (TryGetFloat(productData, FAT_100G_KEY, out float fat100g))
                    Fat100g = fat100g;

                if (TryGetFloat(productData, SATURATED_FAT_100G_KEY, out float saturatedFat100g))
                    SaturatedFat100g = saturatedFat100g;

                if (TryGetFloat(productData, PROTEINS_100G_KEY, out float proteins100g))
                    Proteins100g = proteins100g;

                if (TryGetFloat(productData, SUGARS_100_KEY, out float sugars100g))
                    Sugars100g = sugars100g;

                if (TryGetFloat(productData, ENERGY_SERVING_KEY, out float energyServing))
                    EnergyServing = energyServing;

                if (TryGetFloat(productData, SODIUM_SERVING_KEY, out float sodiumServing))
                    SodiumServing = sodiumServing;

                if (TryGetFloat(productData, SALT_SERVING_KEY, out float saltServing))
                    SaltServing = saltServing;

                if (TryGetFloat(productData, FAT_SERVING_KEY, out float fatServing))
                    FatServing = fatServing;

                if (TryGetFloat(productData, SATURATED_FAT_SERVING_KEY, out float saturatedFatServing))
                    SaturatedFat100g = saturatedFatServing;

                if (TryGetFloat(productData, PROTEINS_SERVING_KEY, out float proteinsServing))
                    ProteinsServing = proteinsServing;

                if (TryGetFloat(productData, SUGARS_SERVING_KEY, out float sugarsServing))
                    SugarsServing = sugarsServing;

                ImgUrl = productData.ImageURL;
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
        public double? EnergyServing { get; set; }
        public double? SodiumServing { get; set; }
        public double? SaltServing { get; set; }
        public double? FatServing { get; set; }
        public double? SaturatedFatServing { get; set; }
        public double? ProteinsServing { get; set; }
        public double? SugarsServing { get; set; }
        public string ImgUrl { get; set; }
    }
}
