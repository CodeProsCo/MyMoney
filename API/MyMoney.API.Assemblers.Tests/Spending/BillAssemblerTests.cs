namespace MyMoney.API.Assemblers.Tests.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Spending;
    using Assemblers.Spending.Interfaces;

    using DataModels.Common;
    using DataModels.Spending;

    using DTO.Response.Spending.Bill;

    using NUnit.Framework;

    using Proxies.Common;
    using Proxies.Spending;

    #endregion

    [TestFixture]
    [Category("API Assemblers")]
    public class BillAssemblerTests
    {
        private IBillAssembler assembler;

        private BillProxy validProxy;

        private BillDataModel validDataModel;

        private Guid validGuid;

        [SetUp]
        public void SetUp()
        {
            validGuid = Guid.NewGuid();
            validDataModel = new BillDataModel
            {
                Amount = 1,
                Category =
                                         new CategoryDataModel
                                         {
                                             CreationTime = DateTime.Now,
                                             Id = validGuid,
                                             Name = "TEST"
                                         },
                CategoryId = validGuid,
                CreationTime = DateTime.Now,
                Id = validGuid,
                Name = "TEST",
                ReoccurringPeriod = 1,
                StartDate = DateTime.Now,
                UserId = validGuid
            };

            validProxy = new BillProxy
            {
                Amount = 1,
                Category = new CategoryProxy { Id = validGuid, Name = "TEST" },
                CategoryId = validGuid,
                Id = validGuid,
                Name = "TEST",
                ReoccurringPeriod = 1,
                StartDate = DateTime.Now,
                UserId = validGuid
            };

            assembler = new BillAssembler();
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
        }

        [Test]
        public void NewAddBillResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewAddBillResponse(validDataModel, validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddBillResponse>(test);
            Assert.IsNotNull(test.Bill);
        }

        [Test]
        public void NewAddBillResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewAddBillResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewAddBillResponse(validDataModel, Guid.Empty); });
        }

        [Test]
        public void NewDeleteBillResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewDeleteBillResponse(true, validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteBillResponse>(test);
            Assert.IsTrue(test.DeleteSuccess);
        }

        [Test]
        public void NewDeleteBillResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewDeleteBillResponse(true, Guid.Empty); });
        }

        [Test]
        public void NewEditBillResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewEditBillResponse(validDataModel, validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditBillResponse>(test);
            Assert.IsNotNull(test.Bill);
        }

        [Test]
        public void NewEditBillResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewEditBillResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewEditBillResponse(validDataModel, Guid.Empty); });
        }

        [Test]
        public void NewGetBillResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewGetBillResponse(validDataModel, validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillResponse>(test);
            Assert.IsNotNull(test.Bill);
        }

        [Test]
        public void NewGetBillResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewGetBillResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillResponse(validDataModel, Guid.Empty); });
        }

        [Test]
        public void NewGetBillsForUserForMonthResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewGetBillsForUserForMonthResponse(new List<KeyValuePair<DateTime, double>>(), validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillsForUserForMonthResponse>(test);
            Assert.IsNotNull(test.Data);
        }

        [Test]
        public void NewGetBillsForUserForMonthResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillsForUserForMonthResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillsForUserForMonthResponse(new List<KeyValuePair<DateTime, double>>(), Guid.Empty); });
        }

        [Test]
        public void NewGetBillsForUserResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewGetBillsForUserResponse(new List<BillDataModel> { validDataModel }, validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillsForUserResponse>(test);
            Assert.IsNotNull(test.Bills);
        }

        [Test]
        public void NewGetBillsForUserResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewGetBillsForUserResponse(null, validGuid); });

            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        assembler.NewGetBillsForUserResponse(new List<BillDataModel> { validDataModel }, Guid.Empty);
                    });
        }

        [Test]
        public void NewBillDataModel_ValidParams_ReturnsDataModel()
        {
            var test = assembler.NewBillDataModel(validProxy);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<BillDataModel>(test);
        }

        [Test]
        public void NewBillDataModel_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewBillDataModel(null); });
        }
    }
}