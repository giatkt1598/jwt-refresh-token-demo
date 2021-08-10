using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relax_app.Constants
{
    public static class ApiConfig
    {
        public const string ApiVersion = "2021-08";
        public static class Paging
        {
            public const int DefaultSize = 100;
            public const int LimitSize = 1000;
        }
    }
}
