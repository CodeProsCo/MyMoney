namespace MyMoney.Web.Assemblers.Spending
{
    #region Usings

    using System;
    using System.Linq;
    using System.Web.Mvc;

    using DTO.Request.Spending;
    using DTO.Response.Spending;

    using Interfaces;

    using JetBrains.Annotations;

    using Proxies.Common;
    using Proxies.Spending;

    using ViewModels.Spending.Bills;
    using ViewModels.Spending.Bills.Enum;

    #endregion

    /// <summary>
    ///     Assembles requests and view models regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Assemblers.Spending.Interfaces.IBillAssembler" />
    [UsedImplicitly]
    public class BillAssembler : IBillAssembler
    {
        #region  Public Methods

        /// <summary>
        ///     Creates an instance of the <see cref="AddBillRequest" />. class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public AddBillRequest NewAddBillRequest(BillViewModel model, string username)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new AddBillRequest { Bill = BillViewModelToProxy(model), Username = username };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="BillViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">The API Response.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        public BillViewModel NewBillViewModel(AddBillResponse apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            return BillProxyToViewModel(apiResponse.Bill);
        }

        /// <summary>
        ///     Creates an instance of the <see cref="BillViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">The API Response.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        public BillViewModel NewBillViewModel(GetBillResponse apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            return BillProxyToViewModel(apiResponse.Bill);
        }

        /// <summary>
        ///     Creates an instance of the <see cref="BillViewModel" />. class.
        /// </summary>
        /// <param name="apiResponse">The API Response.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        public BillViewModel NewBillViewModel(EditBillResponse apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            return BillProxyToViewModel(apiResponse.Bill);
        }

        /// <summary>
        ///     Creates an instance of the <see cref="DeleteBillRequest" />. class.
        /// </summary>
        /// <param name="billId">The bill Id.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public DeleteBillRequest NewDeleteBillRequest(Guid billId, string username)
        {
            if (billId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(billId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new DeleteBillRequest { BillId = billId, Username = username };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="EditBillRequest" />. class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public EditBillRequest NewEditBillRequest(BillViewModel model, string username)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new EditBillRequest { Username = username, Bill = BillViewModelToProxy(model) };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillRequest" />. class.
        /// </summary>
        /// <param name="billId">The bill identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public GetBillRequest NewGetBillRequest(Guid billId, string username)
        {
            if (billId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(billId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new GetBillRequest { BillId = billId, Username = username };
        }

        /// <summary>
        ///     Creates an instance of the <see cref="GetBillsForUserForMonthRequest" />. class.
        /// </summary>
        /// <param name="monthNumber">The month number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userEmail">The user email.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public GetBillsForUserForMonthRequest NewGetBillsForUserForMonthRequest(
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

            return new GetBillsForUserForMonthRequest
            {
                UserId = userId,
                MonthNumber = monthNumber,
                Username = userEmail
            };
        }

        /// <summary>
        ///     Assembles an instance of the <see cref="GetBillsForUserRequest" /> class based on the given
        ///     <see cref="Guid" />.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public GetBillsForUserRequest NewGetBillsForUserRequest(Guid id, string username)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            return new GetBillsForUserRequest { UserId = id, Username = username };
        }

        /// <summary>
        ///     Assembles an instance of the <see cref="ManageBillsViewModel" /> class based on the given
        ///     <see cref="GetBillsForUserResponse" />.
        /// </summary>
        /// <param name="apiResponse">The response object.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        public ManageBillsViewModel NewManageBillsViewModel(GetBillsForUserResponse apiResponse)
        {
            if (apiResponse == null)
            {
                throw new ArgumentNullException(nameof(apiResponse));
            }

            var timePeriodOptions = new SelectList(Enum.GetNames(typeof(TimePeriod)));
            var categoryOptions = new SelectList(Enum.GetNames(typeof(BillCategory)));

            return new ManageBillsViewModel
                       {
                           AddModel =
                               new AddBillViewModel
                                   {
                                       Bill =
                                           new BillViewModel
                                               {
                                                   StartDate =
                                                       DateTime.Now
                                               },
                                       TimePeriodOptions = timePeriodOptions,
                                       CategoryOptions = categoryOptions
                                   },
                           EditModel =
                               new EditBillViewModel
                                   {
                                       Bill =
                                           new BillViewModel
                                               {
                                                   StartDate =
                                                       DateTime.Now
                                               },
                                       TimePeriodOptions = timePeriodOptions,
                                       CategoryOptions = categoryOptions
                                   },
                           Bills = apiResponse.Bills.Select(BillProxyToViewModel).ToList()
                       };
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Converts an instance of the <see cref="BillProxy" /> class to a <see cref="BillViewModel" /> class.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <returns>The view model.</returns>
        private static BillViewModel BillProxyToViewModel(BillProxy proxy)
        {
            return new BillViewModel
            {
                Amount = proxy.Amount,
                Category = proxy.Category.Name,
                Name = proxy.Name,
                ReoccurringPeriod = (TimePeriod)proxy.ReoccurringPeriod,
                StartDate = proxy.StartDate,
                Id = proxy.Id,
                UserId = proxy.UserId
            };
        }

        /// <summary>
        ///     Converts an instance of the <see cref="BillViewModel" /> class to a <see cref="BillProxy" /> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The proxy.</returns>
        private static BillProxy BillViewModelToProxy(BillViewModel model)
        {
            return new BillProxy
            {
                Amount = model.Amount,
                Category = new CategoryProxy { Name = model.Category },
                Name = model.Name,
                ReoccurringPeriod = (int)model.ReoccurringPeriod,
                StartDate = model.StartDate,
                UserId = model.UserId,
                Id = model.Id
            };
        }

        #endregion
    }
}