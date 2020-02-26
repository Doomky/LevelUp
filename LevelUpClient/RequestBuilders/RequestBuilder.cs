using LevelUpRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpClient
{
    public abstract class RequestBuilder<TRequest> : RequestBuilderBase<TRequest> where TRequest : Request, new()
    {

    }
}
