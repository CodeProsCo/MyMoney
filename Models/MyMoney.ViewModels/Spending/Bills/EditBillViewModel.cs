using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.ViewModels.Spending.Bills
{
    using System.Web.Mvc;

    public class EditBillViewModel
    {

        public BillViewModel Bill { get; set; }

        public SelectList CategoryOptions { get; set; }

        public SelectList TimePeriodOptions { get; set; }
    }
}
