using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.API.DataTransformers.Spending.Interfaces
{
    using DataModels.Spending;

    public interface IExpenditureDataTransformer
    {
        IList<KeyValuePair<DateTime, double>> GetRollingExpenditureSum(IEnumerable<ExpenditureDataModel> expenditure);
    }
}
