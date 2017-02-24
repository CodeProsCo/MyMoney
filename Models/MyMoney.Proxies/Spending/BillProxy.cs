namespace MyMoney.Proxies.Spending
{
    using System;

    using Common;

    public class BillProxy
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public double Amount { get; set; }

        public CategoryProxy Category { get; set; }

        public Guid CategoryId { get; set; }

        public int ReocurringPeriod { get; set; }

        public Guid UserId { get; set; }
    }
}
