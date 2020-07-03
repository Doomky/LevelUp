using LevelUpClient.RequestBuilders;
using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class AddCustomFoodEntryRequestHandler : RequestHandler<AddCustomFoodEntryDTORequest, AddCustomFoodEntryDTOResponse>
    {
        public AddCustomFoodEntryRequestHandler(string fullAddress) : base(fullAddress)
        {

        }

        public override AddCustomFoodEntryDTORequest RequestBuilder()
        {
            return new ConsoleAddCustomFoodEntryRequestBuilder()
                .WithName()
                // 100g
                .WithEnergy100g()
                .WithFat100g()
                .WithProteins100g()
                .WithSalt100g()
                .WithSaturatedFat100g()
                .WithSodium100g()
                .WithSugars100g()
                // serving
                .WithEnergyServing()
                .WithFatServing()
                .WithProteinsServing()
                .WithSaltServing()
                .WithSaturatedFatServing()
                .WithSodiumServing()
                .WithSugarsServing()
                .Build();
        }
    }
}
