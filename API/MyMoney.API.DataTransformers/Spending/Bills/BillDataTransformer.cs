namespace MyMoney.API.DataTransformers.Spending.Bills
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DataModels.Spending;

    using Interfaces;

    #endregion

    public class BillDataTransformer : IBillDataTransformer
    {
        #region  Public Methods

        public Dictionary<DateTime, double> GetOutgoingBillsForMonth(int monthNumber, IList<BillDataModel> bills)
        {
            var dailyBills = bills.Where(x => x.ReoccurringPeriod == 0).ToList();
            var weeklyBills = bills.Where(x => x.ReoccurringPeriod == 1).ToList();
            var monthlyBills = bills.Where(x => x.ReoccurringPeriod == 2).ToList();
            var yearlyBills = bills.Where(x => x.ReoccurringPeriod == 3).ToList();
            var retVal = new Dictionary<DateTime, double>();

            for (var date = new DateTime(DateTime.Now.Year, monthNumber, 1);
                 date < new DateTime(DateTime.Now.Year, monthNumber + 1, 1);
                 date = date.AddDays(1))
            {
                double amount = 0;
                var currentDate = date;

                if (dailyBills.Any())
                {
                    amount += dailyBills.Sum(bill => bill.Amount);
                }

                if (monthlyBills.Any(x => x.StartDate.Day == date.Day))
                {
                    var todaysBills = monthlyBills.Where(x => x.StartDate.Day == currentDate.Day);

                    amount += todaysBills.Sum(bill => bill.Amount);
                }

                if (yearlyBills.Any(x => x.StartDate.Day == date.Day && x.StartDate.Month == monthNumber))
                {
                    var todaysBills =
                        yearlyBills.Where(x => x.StartDate.Day == currentDate.Day && x.StartDate.Month == monthNumber);

                    amount += todaysBills.Sum(bill => bill.Amount);
                }

                if (amount > 0)
                {
                    retVal.Add(date, amount);
                }
            }

            return retVal;
        }

        #endregion
    }
}