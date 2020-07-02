using LevelUpClient.RequestHandler.Interfaces;
using LevelUpDTO;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpClient.RequestHandler
{
    public abstract class RequestHandler<TRequest> : IRequestHandler
        where TRequest : DTORequest
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
            switch (Request.GetMethodType())
            {
                case DTORequest.Method.GET:
                    return await httpClient.GetAsync(FullAddress);
                case DTORequest.Method.POST:
                    string jsonString = JsonSerializer.Serialize(Request);
                    HttpContent httpContent = new StringContent(jsonString);
                    return await httpClient.PostAsync(FullAddress, httpContent);
                default:
                    throw new NotSupportedException(Request.GetMethodType() + " is not supported yet");
            }
        }
    }
}
