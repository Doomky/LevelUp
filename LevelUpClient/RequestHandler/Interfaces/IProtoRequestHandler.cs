using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LevelUpClient.RequestHandler.Interfaces
{
    public interface  IProtoRequestHandler
    {
        public string FullAddress { get; set; }

        public DTOResponse  Execute(HttpClient httpClient);

        public DTOResponse Handle(HttpClient httpClient);

    }
}
