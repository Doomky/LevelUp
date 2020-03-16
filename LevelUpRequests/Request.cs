using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpRequests
{
    public abstract class Request
    {
        public enum Method
        {
            GET,
            POST,
        }

        private Method _methodType;
        public Method MethodType 
        { 
            get => _methodType;
            private set 
            {
                _methodType = value; 
            }
        }

        protected Request(Method methodType)
        {
            this.MethodType = methodType;
        }
    }
}
