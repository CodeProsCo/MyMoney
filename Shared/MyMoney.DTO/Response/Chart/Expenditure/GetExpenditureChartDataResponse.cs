using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DTO.Response.Chart.Expenditure
{
    public class GetExpenditureChartDataResponse : BaseResponse
    {
        public IList<KeyValuePair<DateTime, double>> Data { get; set; }
    }
}
