using LevelUpClient.RequestHandler.Interfaces;
using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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
    }
}
