namespace MyMoney.Web.Assemblers.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    using Interfaces;

    using JetBrains.Annotations;

    using Proxies.Common;
    using Proxies.Spending;

    using ViewModels.Enum;
    using ViewModels.Spending.Bills.Enum;
    using ViewModels.Spending.Expenditure;

    #endregion

    /// <summary>
    ///     Assembles requests and view models regarding expenditure.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Assemblers.Spending.Interfaces.IExpenditureAssembler" />
    [UsedImplicitly]
    public class ExpenditureAssembler : IExpenditureAssembler
    {
        #region  Public Methods

        /// <summary>
        ///     Creates an instance of the <see cref="AddExpenditureRequest" />. class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public AddExpenditureRequest NewAddExpenditureRequest(ExpenditureViewModel model, string username)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new AddExpenditureRequest { Expenditure = ExpenditureViewModelToProxy(model), Username = username };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="ExpenditureViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">The API Response.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        public ExpenditureViewModel NewExpenditureViewModel(AddExpenditureResponse apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            return ExpenditureProxyToViewModel(apiResponse.Expenditure);
        }

        /// <summary>
        ///     Creates an instance of the <see cref="ExpenditureViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">The API Response.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        public ExpenditureViewModel NewExpenditureViewModel(GetExpenditureResponse apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            return ExpenditureProxyToViewModel(apiResponse.Expenditure);
        }

        /// <summary>
        ///     Creates an instance of the <see cref="ExpenditureViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">The API Response.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        public ExpenditureViewModel NewExpenditureViewModel(EditExpenditureResponse apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            return ExpenditureProxyToViewModel(apiResponse.Expenditure);
        }

        /// <summary>
        ///     Creates an instance of the <see cref="DeleteExpenditureRequest" />. class.
        /// </summary>
        /// <param name="expenditureId">The expenditure Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public DeleteExpenditureRequest NewDeleteExpenditureRequest(Guid expenditureId, string username)
        {
            if (expenditureId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expenditureId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new DeleteExpenditureRequest { ExpenditureId = expenditureId, Username = username };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="EditExpenditureRequest" />. class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public EditExpenditureRequest NewEditExpenditureRequest(ExpenditureViewModel model, string username)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new EditExpenditureRequest { Username = username, Expenditure = ExpenditureViewModelToProxy(model) };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="GetExpenditureRequest" />. class.
        /// </summary>
        /// <param name="expenditureId">The expenditure identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public GetExpenditureRequest NewGetExpenditureRequest(Guid expenditureId, string username)
        {
            if (expenditureId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expenditureId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new GetExpenditureRequest { ExpenditureId = expenditureId, Username = username };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="GetExpendituresForUserForMonthRequest" />. class.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public GetExpendituresForUserForMonthRequest NewGetExpenditureForUserForMonthRequest(
            int monthNumber,
            Guid userId,
            string userEmail)
        {
            if (monthNumber < 1 || monthNumber > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(monthNumber));
            }

            if (string.IsNullOrEmpty(userEmail))
            {
                throw new ArgumentNullException(nameof(userEmail));
            }

            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return new GetExpendituresForUserForMonthRequest
            {
                UserId = userId,
                MonthNumber = monthNumber,
                Username = userEmail
            };
        }

        /// <summary>
        ///     Assembles an instance of the <see cref="GetExpendituresForUserRequest" /> class based on the given
        ///     <see cref="Guid" />.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public GetExpendituresForUserRequest NewGetExpenditureForUserRequest(Guid id, string username)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new GetExpendituresForUserRequest { UserId = id, Username = username };
        }

        /// <summary>
        ///     Assembles an instance of the <see cref="IList{ExpenditureViewModel}" /> class based on the given
        ///     <see cref="GetExpendituresForUserResponse" />.
        /// </summary>
        /// <param name="apiResponse">The response object.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        public TrackExpenditureViewModel NewTrackExpenditureViewModel(GetExpendituresForUserResponse apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            return new TrackExpenditureViewModel
            {
                AddExpenditure =
                               new AddExpenditureViewModel
                               {
                                   CategoryOptions =
                                           new SelectList(
                                           Enum.GetValues(
                                               typeof(Category))),
                                   Expenditure =
                                           new ExpenditureViewModel
                                           {
                                               DateOccurred = DateTime.Now
                                           },
                                   TimePeriodOptions =
                                           new SelectList(
                                           Enum.GetValues(
                                               typeof(TimePeriod)))
                               },
                Expenditures =
                               apiResponse.Expenditures.Select(ExpenditureProxyToViewModel)
                               .ToList(),
                EditExpenditure =
                               new EditExpenditureViewModel
                               {
                                   CategoryOptions =
                                           new SelectList(
                                           Enum.GetValues(
                                               typeof(Category))),
                                   Expenditure =
                                           new ExpenditureViewModel
                                           {
                                               DateOccurred
                                                       =
                                                       DateTime
                                                       .Now
                                           },
                                   TimePeriodOptions =
                                           new SelectList(
                                           Enum.GetValues(
                                               typeof(TimePeriod)))
                               }
            };
        }

        public IList<ExpenditureViewModel> NewExpenditureViewModelList(GetExpendituresForUserForMonthResponse apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            return apiResponse.Data.Select(ExpenditureProxyToViewModel).ToList();
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Converts an instance of the <see cref="ExpenditureProxy" /> class to a <see cref="ExpenditureViewModel" /> class.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <returns>The view model.</returns>
        private static ExpenditureViewModel ExpenditureProxyToViewModel(ExpenditureProxy proxy)
        {
            return new ExpenditureViewModel
            {
                Amount = proxy.Amount,
                Category = proxy.Category.Name,
                Description = proxy.Description,
                DateOccurred = proxy.DateOccurred,
                Id = proxy.Id,
                UserId = proxy.UserId
            };
        }

        /// <summary>
        ///     Converts an instance of the <see cref="ExpenditureViewModel" /> class to a <see cref="ExpenditureProxy" /> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The proxy.</returns>
        private static ExpenditureProxy ExpenditureViewModelToProxy(ExpenditureViewModel model)
        {
            return new ExpenditureProxy
            {
                Amount = model.Amount,
                Category = new CategoryProxy { Name = model.Category },
                Description = model.Description,
                DateOccurred = model.DateOccurred,
                UserId = model.UserId,
                Id = model.Id
            };
        }

        #endregion
    }
}