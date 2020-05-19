using LevelUpClient.RequestHandler.Interfaces;
using LevelUpRequests;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpClient.RequestHandler
{
    public abstract class RequestHandler<TRequest> : IRequestHandler
        where TRequest : Request
    {
        protected RequestHandler(string fullAddress)
        {
            FullAddress = fullAddress;
        }

        public TRequest Request { get; set; }
        public string FullAddress { get; set; }

        public abstract TRequest RequestBuilder();
        public virtual void Execute(HttpClient httpClient)
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

        public void Handle(HttpClient httpClient)
        {
            Request = RequestBuilder();
            Execute(httpClient);
        }

        public async Task<HttpResponseMessage> ExecuteMethod(HttpClient httpClient)
        {
            switch (Request.MethodType)
            {
                case LevelUpRequests.Request.Method.GET:
                    return await httpClient.GetAsync(FullAddress);
                case LevelUpRequests.Request.Method.POST:
                    string jsonString = JsonSerializer.Serialize(Request);
                    HttpContent httpContent = new StringContent(jsonString);
                    return await httpClient.PostAsync(FullAddress, httpContent);
                default:
                    throw new NotSupportedException(Request.MethodType + " is not supported yet");
            }
        }
    }
}
