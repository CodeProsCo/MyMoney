using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.ViewModels.Spending.Expenditure
{
    public class TrackExpenditureViewModel
    {
        public AddExpenditureViewModel AddExpenditure;

        public IList<ExpenditureViewModel> Expenditures { get; set; }

        public EditExpenditureViewModel EditExpenditure { get; set; }
    }
}
