using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.API.Assemblers.Spending.Interfaces
{
    using DataModels.Spending;

    using DTO.Response.Spending;

    using Proxies.Spending;

    public interface IBillAssembler
    {
        GetBillInformationResponse NewGetBillInformationResponse(IList<BillDataModel> bills, Guid requestReference);

        BillDataModel NewBillDataModel(BillProxy bill);

        AddBillResponse NewAddBillResponse(BillDataModel bill, Guid requestReference);
    }
}
