using LevelUpClient.RequestHandler.Interfaces;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelUpClient.RequestHandler
{
    public abstract class RequestHandler<TRequest> : IRequestHandler
        where TRequest : Request
    {
        protected RequestHandler(string fullAdress)
        {
            FullAdress = fullAdress;
        }

        public TRequest Request { get; set; }
        public string FullAdress { get; set; }

        public abstract TRequest RequestBuilder();
        public abstract void Execute(HttpClient httpClient);
        public void Handle(HttpClient httpClient)
        {
            Request = RequestBuilder();
            Execute(httpClient);
        }

        public async Task<HttpResponseMessage> ExeuteMethod(HttpClient httpClient)
        {
            switch (Request.MethodType)
            {
                case LevelUpRequests.Request.Method.GET:
                    return await httpClient.GetAsync(FullAdress);
                case LevelUpRequests.Request.Method.POST:
                    string jsonString = JsonSerializer.Serialize<TRequest>(Request);
                    HttpContent httpContent = new StringContent(jsonString);
                    return await httpClient.PostAsync(FullAdress, httpContent);
                default:
                    throw new NotSupportedException(Request.MethodType + " is not supported yet");
            }
        }
    }
}
