using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.API.DataTransformers.Spending.Bills.Interfaces
{
    using DataModels.Spending;

    public interface IBillDataTransformer
    {
        IList<KeyValuePair<DateTime, double>> GetOutgoingBillsForMonth(int monthNumber, IList<BillDataModel> bills);
    }
}
