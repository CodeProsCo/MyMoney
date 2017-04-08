using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.ViewModels.Saving.Goal
{
    public class ManageGoalsViewModel
    {
        public AddGoalViewModel AddGoal { get; set; }

        public EditGoalViewModel EditGoal { get; set; }

        public IList<GoalViewModel> Goals { get; set; }
    }
}

