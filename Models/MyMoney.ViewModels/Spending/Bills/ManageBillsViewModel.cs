namespace MyMoney.ViewModels.Spending.Bills
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    using Enum;

    #endregion

    public class ManageBillsViewModel
    {
        #region  Properties

        public AddBillViewModel AddModel { get; set; }

        public IEnumerable<IGrouping<string, BillViewModel>> BillCategories => Bills.GroupBy(x => x.Category);

        public int BillCount => Bills?.Count ?? 0;

        public IEnumerable<IGrouping<TimePeriod, BillViewModel>> BillPeriods => Bills.GroupBy(x => x.ReoccurringPeriod);

        public IList<BillViewModel> Bills { get; set; }

        public EditBillViewModel EditModel { get; set; }

        #endregion
    }
}