namespace MyMoney.Proxies.Spending
{
    #region Usings

    using System;

    using Common;

    #endregion

    public class BillProxy
    {
        #region  Properties

        public double Amount { get; set; }

        public CategoryProxy Category { get; set; }

        public Guid CategoryId { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int ReocurringPeriod { get; set; }

        public DateTime StartDate { get; set; }

        public Guid UserId { get; set; }

        #endregion
    }
}