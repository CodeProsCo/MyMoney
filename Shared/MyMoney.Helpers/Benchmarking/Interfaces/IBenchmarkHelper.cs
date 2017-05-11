using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Helpers.Benchmarking.Interfaces
{
    public interface IBenchmarkHelper
    {
        Benchmark Create(string uri);

        Benchmark Create(Uri uri);
    }
}
