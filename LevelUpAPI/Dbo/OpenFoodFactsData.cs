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
        private const string SATURED_FAT_100G_KEY = "satured_fat_100g";
        private const string PROTEIN_100G_KEY = "protein_100g";


        private bool TryGetDouble(ProductData productData, string key, out double value)
        {
            value = 0;
            return productData.Nutriments.TryGetValue(key, out string valueStr) && Double.TryParse(valueStr, out value);
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
                if (TryGetDouble(productData, ENERGY_100G_KEY, out double energy100g))
                {
                    Energy100g = energy100g;
                }

                if (TryGetDouble(productData, SODIUM_100G_KEY, out double sodium100g))
                {
                    Sodium100g = sodium100g;
                }

                if (TryGetDouble(productData, SALT_100G_KEY, out double salt100g))
                {
                    Salt100g = salt100g;
                }

                if (TryGetDouble(productData, FAT_100G_KEY, out double fat100g))
                {
                    Fat100g = fat100g;
                }

                if (TryGetDouble(productData, SATURED_FAT_100G_KEY, out double saturedFat100g))
                {
                    SaturedFat100g = saturedFat100g;
                }

                if (TryGetDouble(productData, PROTEIN_100G_KEY, out double protein100g))
                {
                    Protein100g = protein100g;
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
        public double? SaturedFat100g { get; set; }
        public double? Protein100g { get; set; }
    }
}
