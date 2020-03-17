using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LevelUpAPI.DataAccess.OpenFoodFacts
{
    public static class URLs
    {
        public static readonly string BaseUrlFormat = "https://{0}-{1}.openfoodfacts.{2}";
        public static readonly string ServiceApiSuffix = "api/v0";
        public static readonly string ServiceCgiSuffix = "cgi";
    }
}
