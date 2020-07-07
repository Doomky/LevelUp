using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LevelUpAPI.Helpers
{
    public static class ActionResultHelpers
    {
        public static ObjectResult FromHttpStatusCode(HttpStatusCode statusCode, Object data)
        {
            ObjectResult result = new ObjectResult(data);
            result.StatusCode = (int)statusCode;
            return result;
        }
    }
}
