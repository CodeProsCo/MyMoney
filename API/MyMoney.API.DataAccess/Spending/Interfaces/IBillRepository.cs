namespace MyMoney.API.DataAccess.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataModels.Spending;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="BillRepository" /> class.
    /// </summary>
    public interface IBillRepository
    {
        #region  Public Methods

        /// <summary>
        ///     Adds a bill to the database.
        /// </summary>
        /// <param name="dataModel">The data model.</param>
        /// <returns>The bill data model.</returns>
        Task<BillDataModel> AddBill(BillDataModel dataModel);

        /// <summary>
        ///     Deletes a bill from the database.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>If successful, true. Otherwise, false.</returns>
        Task<bool> DeleteBill(Guid billId);

        /// <summary>
        ///     Edits a bill in the database.
        /// </summary>
        /// <param name="bill">The bill.</param>
        /// <returns>The updated bill data mode.</returns>
        Task<BillDataModel> EditBill(BillDataModel bill);

        /// <summary>
        ///     Gets a bill.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <returns>The bill data model.</returns>
        Task<BillDataModel> GetBill(Guid billId);

        /// <summary>
        ///     Gets the bills for the given user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The list of bills.</returns>
        Task<IList<BillDataModel>> GetBillsForUser(Guid userId);

        #endregion
    }
}