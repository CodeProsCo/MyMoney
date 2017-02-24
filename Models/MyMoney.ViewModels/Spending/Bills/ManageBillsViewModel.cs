namespace MyMoney.ViewModels.Spending.Bills
{
    using System.Collections.Generic;
    using System.Linq;

    using Enum;

    public class ManageBillsViewModel
    {
        #region  Properties

        public AddBillViewModel AddModel { get; set; }

        public IEnumerable<IGrouping<string, BillViewModel>> BillCategories => Bills.GroupBy(x => x.Category);

        public IEnumerable<IGrouping<TimePeriod, BillViewModel>> BillPeriods => Bills.GroupBy(x => x.ReoccuringPeriod);

        public int BillCount => Bills?.Count ?? 0;

        public IList<BillViewModel> Bills { get; set; }

        #endregion
    }
}