using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.API.Assemblers.Saving.Interfaces
{
    using MyMoney.DataModels.Saving;
    using MyMoney.DTO.Response.Saving.Goal;
    using MyMoney.Proxies.Saving;

    public interface IGoalAssembler
    {
        GoalDataModel NewGoalDataModel(GoalProxy proxy);

        AddGoalResponse NewAddGoalResponse(GoalDataModel addedModel, Guid requestReference);

        DeleteGoalResponse NewDeleteGoalResponse(bool deleteSuccess, Guid requestReference);

        EditGoalResponse NewEditGoalResponse(GoalDataModel updatedDataModel, Guid requestReference);

        GetGoalResponse NewGetGoalResponse(GoalDataModel dataModel, Guid requestReference);

        GetGoalsForUserResponse NewGetGoalsForUserResponse(IList<GoalDataModel> goals, Guid requestReference);
    }
}
