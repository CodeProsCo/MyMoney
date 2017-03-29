using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMoney.DTO.Request.Interfaces;

namespace MyMoney.DTO.Request.Chart.Expenditure
{
    public class GetExpenditureChartDataRequest : BaseRequest, IGetRequest
    {
        public GetExpenditureChartDataRequest() : base("chart/expenditure/month/{0}/{1}/{2}")
        {
        }

        public Guid UserId { get; set; }

        public int Month { get; set; }

        public string FormatRequestUri()
        {
            return string.Format(GetAction(), UserId, Month, RequestReference);
        }
    }
}
