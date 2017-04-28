namespace MyMoney.Web.Assemblers.Tests.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Assemblers.Spending;
    using Assemblers.Spending.Interfaces;

    using DTO.Request.Spending.Bill;
    using DTO.Response.Spending.Bill;

    using NUnit.Framework;

    using Proxies.Common;
    using Proxies.Spending;

    using ViewModels.Common;
    using ViewModels.Enum;
    using ViewModels.Spending.Bill;

    #endregion

    [Category("Web Assemblers")]
    [TestFixture]
    public class BillAssemblerTests
    {
        #region Fields

        private IBillAssembler assembler;

        private AddBillResponse validAddBillResponse;

        private Guid validBillId;

        private BillProxy validBillProxy;

        private BillViewModel validBillViewModel;

        private EditBillResponse validEditBillResponse;

        private GetBillResponse validGetBillResponse;

        private GetBillsForUserResponse validGetBillsForUserResponse;

        private Guid validUserId;

        private string validUsername;

        #endregion

        #region Methods

        [Test]
        public void NewAddBillRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewAddBillRequest(null, validUsername); });

            Assert.Throws<ArgumentNullException>(delegate { assembler.NewAddBillRequest(validBillViewModel, null); });
        }

        [Test]
        public void NewAddBillRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewAddBillRequest(validBillViewModel, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddBillRequest>(test);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreEqual(test.Bill.UserId, validBillViewModel.UserId);
            Assert.AreEqual(test.Bill.Amount, validBillViewModel.Amount);
            Assert.AreEqual(test.Bill.Category.Name, validBillViewModel.Category);
            Assert.AreEqual(test.Bill.Id, validBillViewModel.Id);
            Assert.AreEqual(test.Bill.Name, validBillViewModel.Name);
            Assert.AreEqual(test.Bill.ReoccurringPeriod, (int)validBillViewModel.ReoccurringPeriod);
            Assert.AreEqual(test.Bill.StartDate, validBillViewModel.StartDate);
        }

        [Test]
        public void NewBillViewModel_AddBillResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        AddBillResponse response = null;

                        // ReSharper disable once ExpressionIsAlwaysNull
                        assembler.NewBillViewModel(response);
                    });
        }

        [Test]
        public void NewBillViewModel_AddBillResponse_ValidParams_ReturnsModel()
        {
            var test = assembler.NewBillViewModel(validAddBillResponse);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<BillViewModel>(test);
            Assert.AreEqual(test.UserId, validAddBillResponse.Bill.UserId);
            Assert.AreEqual(test.Amount, validAddBillResponse.Bill.Amount);
            Assert.AreEqual(test.Category, validAddBillResponse.Bill.Category.Name);
            Assert.AreEqual(test.Id, validAddBillResponse.Bill.Id);
            Assert.AreEqual(test.Name, validAddBillResponse.Bill.Name);
            Assert.AreEqual((int)test.ReoccurringPeriod, validAddBillResponse.Bill.ReoccurringPeriod);
            Assert.AreEqual(test.StartDate, validAddBillResponse.Bill.StartDate);
        }

        [Test]
        public void NewBillViewModel_EditBillResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        EditBillResponse response = null;

                        // ReSharper disable once ExpressionIsAlwaysNull
                        assembler.NewBillViewModel(response);
                    });
        }

        [Test]
        public void NewBillViewModel_EditBillResponse_ValidParams_ReturnsModel()
        {
            var test = assembler.NewBillViewModel(validEditBillResponse);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<BillViewModel>(test);
            Assert.AreEqual(test.UserId, validEditBillResponse.Bill.UserId);
            Assert.AreEqual(test.Amount, validEditBillResponse.Bill.Amount);
            Assert.AreEqual(test.Category, validEditBillResponse.Bill.Category.Name);
            Assert.AreEqual(test.Id, validEditBillResponse.Bill.Id);
            Assert.AreEqual(test.Name, validEditBillResponse.Bill.Name);
            Assert.AreEqual((int)test.ReoccurringPeriod, validEditBillResponse.Bill.ReoccurringPeriod);
            Assert.AreEqual(test.StartDate, validEditBillResponse.Bill.StartDate);
        }

        [Test]
        public void NewBillViewModel_GetBillResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        GetBillResponse response = null;

                        // ReSharper disable once ExpressionIsAlwaysNull
                        assembler.NewBillViewModel(response);
                    });
        }

        [Test]
        public void NewBillViewModel_GetBillResponse_ValidParams_ReturnsModel()
        {
            var test = assembler.NewBillViewModel(validGetBillResponse);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<BillViewModel>(test);
            Assert.AreEqual(test.UserId, validGetBillResponse.Bill.UserId);
            Assert.AreEqual(test.Amount, validGetBillResponse.Bill.Amount);
            Assert.AreEqual(test.Category, validGetBillResponse.Bill.Category.Name);
            Assert.AreEqual(test.Id, validGetBillResponse.Bill.Id);
            Assert.AreEqual(test.Name, validGetBillResponse.Bill.Name);
            Assert.AreEqual((int)test.ReoccurringPeriod, validGetBillResponse.Bill.ReoccurringPeriod);
            Assert.AreEqual(test.StartDate, validGetBillResponse.Bill.StartDate);
        }

        [Test]
        public void NewDeleteBillRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewDeleteBillRequest(Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewDeleteBillRequest(validBillId, string.Empty); });
        }

        [Test]
        public void NewDeleteBillRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewDeleteBillRequest(validBillId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteBillRequest>(test);
            Assert.AreEqual(test.BillId, validBillId);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
        }

        [Test]
        public void NewEditBillRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewEditBillRequest(null, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewEditBillRequest(validBillViewModel, string.Empty); });
        }

        [Test]
        public void NewEditBillRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewEditBillRequest(validBillViewModel, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditBillRequest>(test);
            Assert.AreEqual(test.Bill.Id, validBillViewModel.Id);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
            Assert.AreEqual(test.Bill.UserId, validBillViewModel.UserId);
        }

        [Test]
        public void NewGetBillRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewGetBillRequest(Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(delegate { assembler.NewGetBillRequest(validBillId, string.Empty); });
        }

        [Test]
        public void NewGetBillRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetBillRequest(validBillId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillRequest>(test);
            Assert.AreEqual(test.BillId, validBillId);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
        }

        [Test]
        public void NewGetBillsForUserForMonthRequest_InvalidParams_ThrowsExceptions()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { assembler.NewGetBillsForUserForMonthRequest(-1, validUserId, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillsForUserForMonthRequest(1, Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillsForUserForMonthRequest(1, validUserId, string.Empty); });
        }

        [Test]
        public void NewGetBillsForUserForMonthRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetBillsForUserForMonthRequest(1, validUserId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillsForUserForMonthRequest>(test);
            Assert.AreEqual(test.MonthNumber, 1);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreEqual(test.UserId, validUserId);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
        }

        [Test]
        public void NewExportViewModel_Csv_ReturnsViewModel()
        {
            var test = assembler.NewExportViewModel(ExportType.Csv, new List<BillProxy> { validBillProxy });

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExportViewModel>(test);
            
            Assert.IsNotNull(test.FileData);
            Assert.IsNotNull(test.FileName);
            Assert.IsNotNull(test.FullFileName);
            
            Assert.AreEqual(ExportType.Csv, test.ExportType);
        }

        [Test]
        public void NewExportViewModel_Json_ReturnsViewModel()
        {
            var test = assembler.NewExportViewModel(ExportType.Json, new List<BillProxy> { validBillProxy });

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExportViewModel>(test);

            Assert.IsNotNull(test.FileData);
            Assert.IsNotNull(test.FileName);
            Assert.IsNotNull(test.FullFileName);

            Assert.AreEqual(ExportType.Json, test.ExportType);
        }

        [Test]
        public void NewExportViewModel_Xml_ReturnsViewModel()
        {
            var test = assembler.NewExportViewModel(ExportType.Xml, new List<BillProxy> { validBillProxy });

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExportViewModel>(test);

            Assert.IsNotNull(test.FileData);
            Assert.IsNotNull(test.FileName);
            Assert.IsNotNull(test.FullFileName);

            Assert.AreEqual(ExportType.Xml, test.ExportType);
        }

        [Test]
        public void NewGetBillsForUserRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillsForUserRequest(Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillsForUserRequest(validUserId, string.Empty); });
        }

        [Test]
        public void NewGetBillsForUserRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetBillsForUserRequest(validUserId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillsForUserRequest>(test);
            Assert.AreEqual(test.UserId, validUserId);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
        }

        [Test]
        public void NewManageBillsViewModel_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewManageBillsViewModel(null); });
        }

        [Test]
        public void NewManageBillsViewModel_ValidParams_ReturnsViewModel()
        {
            var test = assembler.NewManageBillsViewModel(validGetBillsForUserResponse);

            Assert.IsNotNull(test);
            Assert.IsNotNull(test.AddModel);
            Assert.IsNotNull(test.EditModel);
            Assert.IsInstanceOf<ManageBillsViewModel>(test);
            Assert.AreEqual(test.Bills.Count, 1);
            Assert.Greater(test.BillCategories.Count(), 0);
            Assert.Greater(test.BillPeriods.Count(), 0);
        }

        [SetUp]
        public void SetUp()
        {
            assembler = new BillAssembler();
            validUsername = "TEST";
            validBillId = Guid.NewGuid();
            validUserId = Guid.NewGuid();

            validBillProxy = new BillProxy
                                 {
                                     Amount = 10,
                                     Category = new CategoryProxy { Id = Guid.NewGuid(), Name = "TEST" },
                                     CategoryId = Guid.NewGuid(),
                                     Id = Guid.NewGuid(),
                                     Name = "TEST",
                                     ReoccurringPeriod = 1,
                                     StartDate = DateTime.MaxValue,
                                     UserId = Guid.NewGuid()
                                 };

            validGetBillResponse = new GetBillResponse { Bill = validBillProxy, RequestReference = Guid.NewGuid() };

            validBillViewModel = new BillViewModel
                                     {
                                         Amount = 10,
                                         Category = "TEST",
                                         Id = Guid.NewGuid(),
                                         Name = "TEST",
                                         ReoccurringPeriod = TimePeriod.Daily,
                                         StartDate = DateTime.MinValue,
                                         UserId = Guid.NewGuid()
                                     };

            validAddBillResponse = new AddBillResponse { Bill = validBillProxy, RequestReference = Guid.NewGuid() };

            validEditBillResponse = new EditBillResponse { Bill = validBillProxy, RequestReference = Guid.NewGuid() };

            validGetBillsForUserResponse = new GetBillsForUserResponse
                                               {
                                                   Bills = new List<BillProxy> { validBillProxy },
                                                   RequestReference = Guid.NewGuid()
                                               };
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
            validUsername = null;
            validBillViewModel = null;
            validAddBillResponse = null;
            validGetBillResponse = null;
            validEditBillResponse = null;
            validBillProxy = null;
            validBillId = Guid.Empty;
        }

        #endregion
    }
}