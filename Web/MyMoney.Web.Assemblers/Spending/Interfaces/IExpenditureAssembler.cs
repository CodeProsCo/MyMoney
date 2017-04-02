namespace MyMoney.Web.Assemblers.Spending.Interfaces
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using MyMoney.DTO.Request.Spending.Expenditure;
    using MyMoney.DTO.Response.Spending.Expenditure;
    using MyMoney.Proxies.Spending;
    using MyMoney.ViewModels.Common;
    using MyMoney.ViewModels.Enum;
    using MyMoney.ViewModels.Spending.Expenditure;

    #endregion

    /// <summary>
    ///     Interface for the <see cref="ExpenditureAssembler" /> class.
    /// </summary>
    public interface IExpenditureAssembler
    {
        #region Methods

        /// <summary>
        ///     Creates an instance of the <see cref="AddExpenditureRequest" />. class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>The request object.</returns>
        AddExpenditureRequest NewAddExpenditureRequest(ExpenditureViewModel model, string username);

        /// <summary>
        ///     Creates an instance of the <see cref="DeleteExpenditureRequest" />. class.
        /// </summary>
        /// <param name="expenditureId">
        ///     The expenditure Id.
        /// </param>
        /// <param name="username">
        ///     The username.
        /// </param>
        /// <returns>
        ///     The request object.
        /// </returns>
        DeleteExpenditureRequest NewDeleteExpenditureRequest(Guid expenditureId, string username);

        /// <summary>
        ///     Creates an instance of the <see cref="EditExpenditureRequest" />. class.
        /// </summary>
        /// <param name="model">
        ///     The model.
        /// </param>
        /// <param name="username">
        ///     The username.
        /// </param>
        /// <returns>
        ///     The request object.
        /// </returns>
        EditExpenditureRequest NewEditExpenditureRequest(ExpenditureViewModel model, string username);

        /// <summary>
        ///     Creates an instance of the <see cref="ExpenditureViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">
        ///     The API Response.
        /// </param>
        /// <returns>
        ///     The view model.
        /// </returns>
        ExpenditureViewModel NewExpenditureViewModel(AddExpenditureResponse apiResponse);

        /// <summary>
        ///     Creates an instance of the <see cref="ExpenditureViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">
        ///     The API Response.
        /// </param>
        /// <returns>
        ///     The view model.
        /// </returns>
        ExpenditureViewModel NewExpenditureViewModel(GetExpenditureResponse apiResponse);

        /// <summary>
        ///     Creates an instance of the <see cref="ExpenditureViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">
        ///     The API Response.
        /// </param>
        /// <returns>
        ///     The view model.
        /// </returns>
        ExpenditureViewModel NewExpenditureViewModel(EditExpenditureResponse apiResponse);

        /// <summary>
        /// Creates a collection of the <see cref="ExpenditureViewModel"/> class for the given response object.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns>The list of view models.</returns>
        IList<ExpenditureViewModel> NewExpenditureViewModelList(GetExpendituresForUserForMonthResponse apiResponse);

        /// <summary>
        ///     Creates an instance of the <see cref="GetExpendituresForUserForMonthRequest" />. class.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        GetExpendituresForUserForMonthRequest NewGetExpenditureForUserForMonthRequest(
            int monthNumber,
            Guid userId,
            string userEmail);

        /// <summary>
        ///     Assembles an instance of the <see cref="GetExpendituresForUserRequest" /> class based on the given
        ///     <see cref="string" />.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        GetExpendituresForUserRequest NewGetExpenditureForUserRequest(Guid userId, string username);

        /// <summary>
        ///     Creates an instance of the <see cref="GetExpenditureRequest" />. class.
        /// </summary>
        /// <param name="expenditureId">The expenditure identifier.</param>
        /// <param name="username">
        ///     The username.
        /// </param>
        /// <returns>
        ///     The request object.
        /// </returns>
        GetExpenditureRequest NewGetExpenditureRequest(Guid expenditureId, string username);

        /// <summary>
        ///     Assembles an instance of the <see cref="IList{ExpenditureViewModel}" /> class based on the given
        ///     <see cref="GetExpendituresForUserResponse" />.
        /// </summary>
        /// <param name="apiResponse">The response object.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        TrackExpenditureViewModel NewTrackExpenditureViewModel(GetExpendituresForUserResponse apiResponse);

        #endregion

        ExportViewModel NewExportViewModel(IList<ExpenditureProxy> apiResponseExpenditures, ExportType exportType);
    }
}