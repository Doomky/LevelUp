using System;

namespace LevelUpDTO
{
    public abstract class DTORequest
    {
        public enum Method
        {
            GET,
            POST,
        }
        protected Method MethodType { get; set; }

        protected DTORequest(Method methodType)
        {
            MethodType = methodType;
        }

        public Method GetMethodType()
        {
            return MethodType;
        }
    }
}
