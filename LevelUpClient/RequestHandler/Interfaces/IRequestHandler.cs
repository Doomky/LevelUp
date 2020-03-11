using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler.Interfaces
{
    public interface IRequestHandler 
    {
        public string FullAdress { get; set; }

        public void Execute(HttpClient httpClient);

        public void Handle(HttpClient httpClient);

    }
}
