using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpDTO
{
    [JsonObject]
    public class AddCustomFoodEntryDTORequest : DTORequest
    {
        public AddCustomFoodEntryDTORequest() : base(Method.POST)
        {
        }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("energy100g")]
        public double? Energy100g { get; set; }
        [JsonProperty("sodium100g")]
        public double? Sodium100g { get; set; }
        [JsonProperty("salt100g")]
        public double? Salt100g { get; set; }
        [JsonProperty("fat100g")]
        public double? Fat100g { get; set; }
        [JsonProperty("staturatedFat100g")]
        public double? SaturatedFat100g { get; set; }
        [JsonProperty("proteins100g")]
        public double? Proteins100g { get; set; }
        [JsonProperty("sugars100g")]
        public double? Sugars100g { get; set; }
        [JsonProperty("energyServing")]
        public double? EnergyServing { get; set; }
        [JsonProperty("sodiumServing")]
        public double? SodiumServing { get; set; }
        [JsonProperty("saltServing")]
        public double? SaltServing { get; set; }
        [JsonProperty("fatServing")]
        public double? FatServing { get; set; }
        [JsonProperty("saltServing")]
        public double? SaturatedFatServing { get; set; }
        [JsonProperty("saturatedFatServing")]
        public double? ProteinsServing { get; set; }
        [JsonProperty("sugarServing")]
        public double? SugarsServing { get; set; }
    }
}
