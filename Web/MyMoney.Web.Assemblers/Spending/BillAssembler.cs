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
    /// Assembles requests and view models regarding bills.
    /// </summary>
    /// <seealso cref="MyMoney.Web.Assemblers.Spending.Interfaces.IBillAssembler" />
    [UsedImplicitly]
    public class BillAssembler : IBillAssembler
    {
        #region  Public Methods

        /// <summary>
        /// Assembles an instance of the <see cref="GetBillInformationRequest" /> class based on the given
        /// <see cref="Guid" />.
        /// </summary>
        /// <param name="id">The user's email address.</param>
        /// <returns>
        /// The request object.
        /// </returns>
        public GetBillInformationRequest NewGetBillInformationRequest(Guid id)
        {
            return new GetBillInformationRequest { UserId = id };
        }

        /// <summary>
        /// Assembles an instance of the <see cref="ManageBillsViewModel" /> class based on the given
        /// <see cref="GetBillInformationResponse" />.
        /// </summary>
        /// <param name="apiResponse">The response object.</param>
        /// <returns>
        /// The view model.
        /// </returns>
        public ManageBillsViewModel NewManageBillsViewModel(GetBillInformationResponse apiResponse)
        {
            return new ManageBillsViewModel
            {
                AddModel =
                               new AddBillViewModel
                               {
                                   StartDate = DateTime.Now,
                                   TimePeriodOptions = new SelectList(Enum.GetNames(typeof(TimePeriod))),
                                   CategoryOptions = new SelectList(Enum.GetNames(typeof(BillCategory)).OrderBy(x => x))
                               },
                Bills =
                               apiResponse.Bills.Select(
                                   x =>
                                   new BillViewModel
                                   {
                                       Amount = x.Amount,
                                       Category = x.Category.Name,
                                       Name = x.Name,
                                       ReoccuringPeriod =
                                               (TimePeriod)x.ReocurringPeriod,
                                       StartDate = x.StartDate
                                   }).ToList()
            };
        }

        public AddBillRequest NewAddBillRequest(AddBillViewModel model, Guid userId)
        {
            return new AddBillRequest
            {
                Bill = new BillProxy
                {
                    Amount = model.Amount,
                    Category = new CategoryProxy
                    {
                        Name = model.Category
                    },
                    Name = model.Name,
                    ReocurringPeriod = (int)model.ReoccuringPeriod,
                    StartDate = model.StartDate,
                    UserId = userId
                }
            };
        }

        public BillViewModel NewBillViewModel(AddBillResponse apiResponse)
        {
            return new BillViewModel
            {
                Amount = apiResponse.Bill.Amount,
                Category = apiResponse.Bill.Category.Name,
                Name = apiResponse.Bill.Name,
                ReoccuringPeriod = (TimePeriod)apiResponse.Bill.ReocurringPeriod,
                StartDate = apiResponse.Bill.StartDate
            };
        }

        #endregion
    }
}