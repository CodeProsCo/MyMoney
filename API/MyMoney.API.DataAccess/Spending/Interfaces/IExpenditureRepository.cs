﻿namespace MyMoney.API.DataAccess.Spending.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataModels.Spending;

    /// <summary>
    /// Interface for the <see cref="ExpenditureRepository"/> class.
    /// </summary>
    public interface IExpenditureRepository
    {
        /// <summary>
        /// Gets the expenditures for the given user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The list of expenditures.</returns>
        Task<IList<ExpenditureDataModel>> GetExpendituresForUser(Guid userId);

        /// <summary>
        /// Obtains an expenditure from the database.
        /// </summary>
        /// <param name="expenditureId">The expenditure identifier.</param>
        /// <returns>The expenditure.</returns>
        Task<ExpenditureDataModel> GetExpenditure(Guid expenditureId);

        /// <summary>
        /// Adds an expenditure to the database.
        /// </summary>
        /// <param name="dataModel">The data model.</param>
        /// <returns>The newly added data model.</returns>
        Task<ExpenditureDataModel> AddExpenditure(ExpenditureDataModel dataModel);

        /// <summary>
        /// Removes an expenditure from the database.
        /// </summary>
        /// <param name="expenditureId">The expenditure identifier.</param>
        /// <returns>If successful, true. Otherwise false.</returns>
        Task<bool> DeleteExpenditure(Guid expenditureId);

        /// <summary>
        /// Updates an expenditure in the database.
        /// </summary>
        /// <param name="expenditure">The edited expenditure.</param>
        /// <returns>The updated data model.</returns>
        Task<ExpenditureDataModel> EditExpenditure(ExpenditureDataModel expenditure);
    }
}