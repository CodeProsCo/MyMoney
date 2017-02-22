using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.API.Orchestrators.Spending
{
    using DTO.Response.Spending;

    using Interfaces;

    using JetBrains.Annotations;

    [UsedImplicitly]
    public class BillOrchestrator : IBillOrchestrator
    {
        #region Implementation of IBillOrchestrator

        public async Task<GetBillInformationResponse> GetBillInformation(Guid userId)
        {
            return null;
        }

        #endregion
    }
}
