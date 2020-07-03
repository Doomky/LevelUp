using LevelUpDTO;
using System;
using System.Net.Http;

namespace LevelUpClient.RequestHandler.Interfaces
{
    public interface IRequestHandler<TDTORequest, TDTOResponse>
        where TDTORequest : DTORequest where TDTOResponse : DTOResponse
    {
        public string FullAddress { get; set; }

        public TDTOResponse Execute(HttpClient httpClient);

        public TDTOResponse Handle(HttpClient httpClient);

    }
}
