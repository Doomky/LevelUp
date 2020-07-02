using LevelUpDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient
{
    public class RequestBuilderBase<TRequest> where TRequest : DTORequest, new()
    {
        public TRequest Request { get; set; }

        public RequestBuilderBase()
        {
            Request = new TRequest();
        }

        public TRequest Build()
        {
            return Request;
        }
    }
}
