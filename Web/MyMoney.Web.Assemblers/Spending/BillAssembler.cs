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

        public AddBillRequest NewAddBillRequest(BillViewModel model, string username)
        {
            return new AddBillRequest { Bill = BillViewModelToProxy(model), Username = username};
        }

        public BillViewModel NewBillViewModel(AddBillResponse apiResponse)
        {
            return BillProxyToViewModel(apiResponse.Bill);
        }

        public BillViewModel NewBillViewModel(GetBillResponse apiResponse)
        {
            return BillProxyToViewModel(apiResponse.Bill);
        }

        public BillViewModel NewBillViewModel(EditBillResponse apiResponse)
        {
            return BillProxyToViewModel(apiResponse.Bill);
        }

        public DeleteBillRequest NewDeleteBillRequest(Guid billId, string username)
        {
            return new DeleteBillRequest { BillId = billId, Username = username };
        }

        public EditBillRequest NewEditBillRequest(BillViewModel model, string username)
        {
            return new EditBillRequest { Username = username, Bill = BillViewModelToProxy(model) };
        }

        /// <summary>
        ///     Assembles an instance of the <see cref="GetBillInformationRequest" /> class based on the given
        ///     <see cref="Guid" />.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///     The request object.
        /// </returns>
        public GetBillInformationRequest NewGetBillInformationRequest(Guid id, string username)
        {
            return new GetBillInformationRequest { UserId = id, Username = username};
        }

        public GetBillRequest NewGetBillRequest(Guid billId, string username)
        {
            return new GetBillRequest { BillId = billId, Username = username };
        }

        /// <summary>
        ///     Assembles an instance of the <see cref="ManageBillsViewModel" /> class based on the given
        ///     <see cref="GetBillInformationResponse" />.
        /// </summary>
        /// <param name="apiResponse">The response object.</param>
        /// <returns>
        ///     The view model.
        /// </returns>
        public ManageBillsViewModel NewManageBillsViewModel(GetBillInformationResponse apiResponse)
        {
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
                                   TimePeriodOptions =
                                           new SelectList(
                                           Enum.GetNames(typeof(TimePeriod))),
                                   CategoryOptions =
                                           new SelectList(
                                           Enum.GetNames(typeof(BillCategory))
                                           .OrderBy(x => x))
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
                                   TimePeriodOptions =
                                           new SelectList(
                                           Enum.GetNames(typeof(TimePeriod))),
                                   CategoryOptions =
                                           new SelectList(
                                           Enum.GetNames(typeof(BillCategory))
                                           .OrderBy(x => x))
                               },
                Bills = apiResponse.Bills.Select(BillProxyToViewModel).ToList()
            };
        }

        #endregion

        #region Private Methods

        private static BillViewModel BillProxyToViewModel(BillProxy proxy)
        {
            return new BillViewModel
            {
                Amount = proxy.Amount,
                Category = proxy.Category.Name,
                Name = proxy.Name,
                ReoccuringPeriod = (TimePeriod)proxy.ReocurringPeriod,
                StartDate = proxy.StartDate,
                Id = proxy.Id
            };
        }

        private static BillProxy BillViewModelToProxy(BillViewModel model)
        {
            return new BillProxy
            {
                Amount = model.Amount,
                Category = new CategoryProxy { Name = model.Category },
                Name = model.Name,
                ReocurringPeriod = (int)model.ReoccuringPeriod,
                StartDate = model.StartDate,
                UserId = model.Id
            };
        }

        #endregion
    }
}