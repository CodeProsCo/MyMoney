namespace MyMoney.ViewModels.Spending.Bills
{
    #region Usings

    using System.Web.Mvc;

    #endregion

    public class AddBillViewModel
    {
        #region  Properties

        public BillViewModel Bill { get; set; }

        public SelectList CategoryOptions { get; set; }

        public SelectList TimePeriodOptions { get; set; }

        #endregion
    }
}