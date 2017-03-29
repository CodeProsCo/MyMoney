using MyMoney.API.DataTransformers.Spending.Interfaces;

namespace MyMoney.API.DataTransformers.Spending
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataModels.Spending;

    public class ExpenditureDataTransformer : IExpenditureDataTransformer
    {
        public IList<KeyValuePair<DateTime, double>> GetRollingExpenditureSum(IEnumerable<ExpenditureDataModel> expenditure)
        {
            var retVal = new List<KeyValuePair<DateTime, double>>();

            foreach (var exp in expenditure.OrderBy(x => x.DateOccurred))
            {
                var existingDate = retVal.FirstOrDefault(x => x.Key.Equals(exp.DateOccurred));

                if (existingDate.Key == DateTime.MinValue)
                {
                    retVal.Add(new KeyValuePair<DateTime, double>(exp.DateOccurred, exp.Amount));
                }
                else
                {
                    retVal.Remove(existingDate);
                    existingDate = new KeyValuePair<DateTime, double>(existingDate.Key, existingDate.Value + exp.Amount);
                    retVal.Add(existingDate);
                }
            }

            return retVal.OrderBy(x => x.Key).ToList();
        }
    }
}