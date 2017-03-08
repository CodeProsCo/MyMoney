using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Helpers.Network
{
    public static class RequestBenchmarkHelper
    {
        public static RequestBenchmark Create(string uri)
        {
            return new RequestBenchmark(uri);
        }
    }
}
