using System;

namespace LevelUpRequests
{
    public abstract class Request
    {
        public enum Method
        {
            GET,
            POST,
        }
        public Method MethodType { get; private set; }

        protected Request(Method methodType)
        {
            MethodType = methodType;
        }
    }
}
