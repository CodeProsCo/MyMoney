using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.API.Assemblers.Spending
{
    using DataModels.Common;
    using DataModels.Spending;

    using DTO.Response.Spending;

    using Interfaces;

    using Proxies.Common;
    using Proxies.Spending;

    public class BillAssembler : IBillAssembler
    {
        #region Implementation of IBillAssembler

        public GetBillInformationResponse NewGetBillInformationResponse(IList<BillDataModel> bills, Guid requestReference)
        {
            return new GetBillInformationResponse
            {
                RequestReference = requestReference,
                Bills = bills.Select(x => new BillProxy
                {
                    Amount = x.Amount,
                    Category = new CategoryProxy
                    {
                        CategoryId = x.Category.Id,
                        Name = x.Category.Name
                    },
                    CategoryId = x.CategoryId,
                    Id = x.Id,
                    Name = x.Name,
                    ReocurringPeriod = x.ReocurringPeriod,
                    StartDate = x.StartDate,
                    UserId = x.UserId
                }).ToList()
            };
        }

        public BillDataModel NewBillDataModel(BillProxy bill)
        {
            return new BillDataModel
            {
                Amount = bill.Amount,
                Category =
                               new CategoryDataModel
                               {
                                   Id = bill.Category.CategoryId,
                                   Name = bill.Category.Name
                               },
                CategoryId = bill.CategoryId,
                Id = bill.Id,
                Name = bill.Name,
                ReocurringPeriod = bill.ReocurringPeriod,
                StartDate = bill.StartDate,
                UserId = bill.UserId
            };
        }

        public AddBillResponse NewAddBillResponse(BillDataModel bill, Guid requestReference)
        {
            return new AddBillResponse
            {
                Bill =
                new BillProxy
                {
                    Amount = bill.Amount,
                    Category =
                            new CategoryProxy
                            {
                                CategoryId = bill.Category.Id,
                                Name = bill.Category.Name
                            },
                    CategoryId = bill.CategoryId,
                    Id = bill.Id,
                    Name = bill.Name,
                    ReocurringPeriod = bill.ReocurringPeriod,
                    StartDate = bill.StartDate,
                    UserId = bill.UserId
                },
                RequestReference = requestReference
            };
        }

        #endregion
    }
}
