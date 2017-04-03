namespace MyMoney.API.DataAccess.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    using MyMoney.API.DataAccess.Saving.Interfaces;
    using MyMoney.DataModels.Saving;
    using MyMoney.Resources;

    #endregion

    [UsedImplicitly]
    public class GoalRepository : IGoalRepository
    {
        #region Fields

        private readonly IDatabaseContext context;

        #endregion

        #region Constructor

        public GoalRepository(IDatabaseContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
        }

        #endregion

        #region Methods

        public async Task<GoalDataModel> AddGoal(GoalDataModel model)
        {
            model.Id = Guid.NewGuid();

            model.CreationTime = DateTime.Now;
            context.Goals.Add(model);

            var rows = await context.SaveChangesAsync();

            return rows > 0 ? model : null;
        }

        public async Task<bool> DeleteGoal(Guid goalId)
        {
            var toDelete = await GetGoal(goalId);

            if (toDelete == null)
            {
                throw new Exception(Goal.Error_CouldNotFindGoal);
            }

            toDelete = context.Goals.Attach(toDelete);
            context.Goals.Remove(toDelete);

            var rows = await context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<GoalDataModel> EditGoal(GoalDataModel model)
        {
            var toEdit = await GetGoal(model.Id);

            if (toEdit == null)
            {
                throw new Exception(Goal.Error_CouldNotFindGoal);
            }

            model.CreationTime = toEdit.CreationTime;
            toEdit = context.Goals.Attach(toEdit);
            context.Goals.Remove(toEdit);

            context.Goals.Add(model);

            var rows = await context.SaveChangesAsync();

            return rows > 0 ? model : null;
        }

        public async Task<GoalDataModel> GetGoal(Guid goalId)
        {
            var goal = await context.Goals.FirstOrDefaultAsync(x => x.Id.Equals(goalId));

            if (goal == null)
            {
                throw new Exception(Goal.Error_CouldNotFindGoal);
            }

            return goal;
        }

        public async Task<IList<GoalDataModel>> GetGoalsForUser(Guid userId)
        {
            return await context.Goals.Where(x => x.UserId.Equals(userId)).ToListAsync();
        }

        #endregion
    }
}