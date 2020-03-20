using LevelUpClient.RequestBuilders;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler
{
    public class UpdateFoodEntryRequestHandler : RequestHandler<UpdateFoodEntryRequest>
    {
        public UpdateFoodEntryRequestHandler(string fullAdress) : base(fullAdress)
        {
        }

        public override void Execute(HttpClient httpClient)
        {
            HttpResponseMessage httpResponse = ExecuteMethod(httpClient).GetAwaiter().GetResult();
            string bodyAsStr = "";
            if (httpResponse.IsSuccessStatusCode)
            {
                bodyAsStr = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            Console.WriteLine(
$@"response:
status code: {(int)httpResponse.StatusCode} {httpResponse.StatusCode}
body: {bodyAsStr}");
        }

        public override UpdateFoodEntryRequest RequestBuilder()
        {
            return new ConsoleUpdateFoodEntryRequestBuilder()
                        .WithUserId()
                        .WithOFFDataId()
                        .Build();
        }
    }
}
