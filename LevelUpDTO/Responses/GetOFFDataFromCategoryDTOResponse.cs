using System;

namespace LevelUpDTO
{
    public class GetOFFDataFromCategoryDTOResponse : DTOResponse
    {
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
        public bool IsCustom { get; set; }

        public GetOFFDataFromCategoryDTOResponse(int id, string code, string name, double? energy100g, double? sodium100g, double? salt100g, double? fat100g, double? saturatedFat100g, double? proteins100g, double? sugars100g, double? energyServing, double? sodiumServing, double? saltServing, double? fatServing, double? saturatedFatServing, double? proteinsServing, double? sugarsServing, string imgUrl, bool isCustom)
        {
            Id = id;
            Code = code;
            Name = name;
            Energy100g = energy100g;
            Sodium100g = sodium100g;
            Salt100g = salt100g;
            Fat100g = fat100g;
            SaturatedFat100g = saturatedFat100g;
            Proteins100g = proteins100g;
            Sugars100g = sugars100g;
            EnergyServing = energyServing;
            SodiumServing = sodiumServing;
            SaltServing = saltServing;
            FatServing = fatServing;
            SaturatedFatServing = saturatedFatServing;
            ProteinsServing = proteinsServing;
            SugarsServing = sugarsServing;
            ImgUrl = imgUrl;
            IsCustom = isCustom;
        }
    }
}
