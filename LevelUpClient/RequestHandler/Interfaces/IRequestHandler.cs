﻿using LevelUpDTO;
using System;
using System.Net.Http;

namespace LevelUpClient.RequestHandler.Interfaces
{
    public interface IRequestHandler<TDTORequest, TDTOResponse> : IProtoRequestHandler
        where TDTORequest : DTORequest 
        where TDTOResponse : DTOResponse
    {
        public string FullAddress { get; set; }

        public DTOResponse Execute(HttpClient httpClient);

        public DTOResponse Handle(HttpClient httpClient);

    }
}
