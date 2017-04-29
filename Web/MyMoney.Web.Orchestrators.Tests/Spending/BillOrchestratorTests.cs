namespace MyMoney.Web.Orchestrators.Tests.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DTO.Request.Spending.Bill;
    using DTO.Response.Spending.Bill;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Spending;
    using Orchestrators.Spending.Interfaces;

    using Proxies.Common;
    using Proxies.Spending;

    using ViewModels.Common;
    using ViewModels.Enum;
    using ViewModels.Spending.Bill;

    using Wrappers;

    #endregion

    [Category("Web Orchestrators")]
    [TestFixture]
    public class BillOrchestratorTests
    {
        #region Constants

        private const string validUsername = "TEST";

        #endregion

        #region Fields

        private IBillAssembler assembler;

        private IBillDataAccess dataAccess;

        private AddBillRequest invalidAddBillRequest;

        private AddBillResponse invalidAddBillResponse;

        private BillViewModel invalidBillViewModel;

        private DeleteBillRequest invalidDeleteBillRequest;

        private DeleteBillResponse invalidDeleteBillResponse;

        private EditBillRequest invalidEditBillRequest;

        private EditBillResponse invalidEditBillResponse;

        private GetBillRequest invalidGetBillRequest;

        private GetBillResponse invalidGetBillResponse;

        private GetBillsForUserForMonthRequest invalidGetBillsForUserForMonthRequest;

        private GetBillsForUserForMonthResponse invalidGetBillsForUserForMonthResponse;

        private GetBillsForUserRequest invalidGetBillsForUserRequest;

        private GetBillsForUserResponse invalidGetBillsForUserResponse;

        private IBillOrchestrator orchestrator;

        private AddBillRequest validAddBillRequest;

        private AddBillResponse validAddBillResponse;

        private BillProxy validBillProxy;

        private DeleteBillRequest validDeleteBillRequest;

        private DeleteBillResponse validDeleteBillResponse;

        private EditBillRequest validEditBillRequest;

        private EditBillResponse validEditBillResponse;

        private GetBillRequest validGetBillRequest;

        private GetBillResponse validGetBillResponse;

        private GetBillsForUserForMonthRequest validGetBillsForUserForMonthRequest;

        private GetBillsForUserForMonthResponse validGetBillsForUserForMonthResponse;

        private GetBillsForUserRequest validGetBillsForUserRequest;

        private GetBillsForUserResponse validGetBillsForUserResponse;

        private ManageBillsViewModel validManageBillsViewModel;

        private BillViewModel validViewModel;

        #endregion

        #region Methods

        [Test]
        public void AddBill_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.AddBill(invalidBillViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<BillViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void AddBill_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.AddBill(null, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<BillViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void ExportBills_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.ExportBills(ExportType.Csv, validUsername, validViewModel.Id).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExportViewModel>>(test);
        }

        [Test]
        public void ExportBills_InvalidParams_ReturnsResponse()
        {
            var test = orchestrator.ExportBills(ExportType.Csv, validUsername, invalidBillViewModel.Id).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExportViewModel>>(test);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void ExportBills_ThrowsException_ReturnsResponse()
        {
            var test = orchestrator.ExportBills(ExportType.Json, validUsername, validViewModel.Id).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExportViewModel>>(test);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void AddBill_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.AddBill(validViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<BillViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new BillOrchestrator(null, dataAccess); });

            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new BillOrchestrator(assembler, null); });
        }

        [Test]
        public void DeleteBill_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.DeleteBill(invalidBillViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.IsNotNull(test);
            Assert.IsFalse(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void DeleteBill_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.DeleteBill(Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.IsNotNull(test);
            Assert.IsFalse(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void DeleteBill_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.DeleteBill(validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void EditBill_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.EditBill(invalidBillViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<BillViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void EditBill_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.EditBill(null, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<BillViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void EditBill_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.EditBill(validViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<BillViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void GetBill_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBill(invalidBillViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<BillViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetBill_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBill(Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<BillViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetBill_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.GetBill(validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<BillViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void GetBillsForUser_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillsForUser(invalidBillViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ManageBillsViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetBillsForUser_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillsForUser(Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ManageBillsViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetBillsForUser_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.GetBillsForUser(validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ManageBillsViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void GetBillsForUserForMonth_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillsForUserForMonth(1, invalidBillViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<KeyValuePair<DateTime, double>>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetBillsForUserForMonth_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillsForUserForMonth(1, Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<KeyValuePair<DateTime, double>>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetBillsForUserForMonth_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.GetBillsForUserForMonth(1, validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<KeyValuePair<DateTime, double>>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [SetUp]
        public void SetUp()
        {
            validViewModel = new BillViewModel
            {
                Amount = 10,
                Category = "TEST",
                Id = Guid.NewGuid(),
                Name = "TEST",
                ReoccurringPeriod = TimePeriod.Daily,
                StartDate = DateTime.Now,
                UserId = Guid.NewGuid()
            };

            validBillProxy = new BillProxy
            {
                Amount = 10,
                Category = new CategoryProxy { Id = Guid.NewGuid(), Name = "TEST" },
                CategoryId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                Name = "TEST",
                ReoccurringPeriod = 1,
                StartDate = DateTime.Now,
                UserId = Guid.NewGuid()
            };

            validManageBillsViewModel = new ManageBillsViewModel();

            validDeleteBillRequest = new DeleteBillRequest { BillId = validBillProxy.Id };
            validDeleteBillResponse = new DeleteBillResponse { DeleteSuccess = true };
            validAddBillRequest = new AddBillRequest { Bill = validBillProxy };
            validAddBillResponse = new AddBillResponse { Bill = validBillProxy };
            validGetBillRequest = new GetBillRequest { BillId = validBillProxy.Id };
            validGetBillResponse = new GetBillResponse { Bill = validBillProxy };
            validGetBillsForUserRequest = new GetBillsForUserRequest { UserId = validBillProxy.Id };
            validGetBillsForUserResponse =
                new GetBillsForUserResponse { Bills = new List<BillProxy> { validBillProxy } };
            validEditBillRequest = new EditBillRequest { Bill = validBillProxy };
            validEditBillResponse = new EditBillResponse { Bill = validBillProxy };
            validGetBillsForUserForMonthRequest = new GetBillsForUserForMonthRequest { UserId = validBillProxy.Id };
            validGetBillsForUserForMonthResponse =
                new GetBillsForUserForMonthResponse { Data = new List<KeyValuePair<DateTime, double>>() };

            invalidBillViewModel = new BillViewModel { Id = Guid.NewGuid() };
            invalidAddBillRequest = new AddBillRequest();
            invalidAddBillResponse = new AddBillResponse { Errors = { new ResponseErrorWrapper() } };
            invalidGetBillRequest = new GetBillRequest();
            invalidGetBillResponse = new GetBillResponse { Errors = { new ResponseErrorWrapper() } };
            invalidDeleteBillRequest = new DeleteBillRequest();
            invalidDeleteBillResponse = new DeleteBillResponse { Errors = { new ResponseErrorWrapper() } };
            invalidGetBillsForUserRequest = new GetBillsForUserRequest();
            invalidGetBillsForUserResponse = new GetBillsForUserResponse { Errors = { new ResponseErrorWrapper() } };
            invalidEditBillRequest = new EditBillRequest();
            invalidEditBillResponse = new EditBillResponse { Errors = { new ResponseErrorWrapper() } };
            invalidGetBillsForUserForMonthRequest = new GetBillsForUserForMonthRequest();
            invalidGetBillsForUserForMonthResponse =
                new GetBillsForUserForMonthResponse { Errors = { new ResponseErrorWrapper() } };

            assembler = Substitute.For<IBillAssembler>();
            dataAccess = Substitute.For<IBillDataAccess>();

            assembler.NewAddBillRequest(validViewModel, validUsername).Returns(validAddBillRequest);
            assembler.NewAddBillRequest(invalidBillViewModel, validUsername).Returns(invalidAddBillRequest);
            assembler.NewAddBillRequest(null, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewBillViewModel(validAddBillResponse).Returns(validViewModel);
            assembler.NewBillViewModel(validEditBillResponse).Returns(validViewModel);
            assembler.NewDeleteBillRequest(validViewModel.Id, validUsername).Returns(validDeleteBillRequest);
            assembler.NewDeleteBillRequest(invalidBillViewModel.Id, validUsername).Returns(invalidDeleteBillRequest);
            assembler.NewDeleteBillRequest(Guid.Empty, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewGetBillRequest(validViewModel.Id, validUsername).Returns(validGetBillRequest);
            assembler.NewGetBillRequest(invalidBillViewModel.Id, validUsername).Returns(invalidGetBillRequest);
            assembler.NewGetBillRequest(Guid.Empty, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewGetBillsForUserRequest(validViewModel.Id, validUsername).Returns(validGetBillsForUserRequest);
            assembler.NewGetBillsForUserRequest(invalidBillViewModel.Id, validUsername)
                .Returns(invalidGetBillsForUserRequest);
            assembler.NewGetBillsForUserRequest(Guid.Empty, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewEditBillRequest(validViewModel, validUsername).Returns(validEditBillRequest);
            assembler.NewEditBillRequest(invalidBillViewModel, validUsername).Returns(invalidEditBillRequest);
            assembler.NewEditBillRequest(null, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewGetBillsForUserForMonthRequest(1, validViewModel.Id, validUsername)
                .Returns(validGetBillsForUserForMonthRequest);
            assembler.NewGetBillsForUserForMonthRequest(1, invalidBillViewModel.Id, validUsername)
                .Returns(invalidGetBillsForUserForMonthRequest);
            assembler.NewManageBillsViewModel(validGetBillsForUserResponse).Returns(validManageBillsViewModel);
            assembler.NewExportViewModel(ExportType.Json, Arg.Any<IList<BillProxy>>()).Throws(new Exception("TEST"));

            dataAccess.AddBill(validAddBillRequest).Returns(validAddBillResponse);
            dataAccess.AddBill(invalidAddBillRequest).Returns(invalidAddBillResponse);
            dataAccess.DeleteBill(validDeleteBillRequest).Returns(validDeleteBillResponse);
            dataAccess.DeleteBill(invalidDeleteBillRequest).Returns(invalidDeleteBillResponse);
            dataAccess.GetBill(validGetBillRequest).Returns(validGetBillResponse);
            dataAccess.GetBill(invalidGetBillRequest).Returns(invalidGetBillResponse);
            dataAccess.GetBillsForUser(validGetBillsForUserRequest).Returns(validGetBillsForUserResponse);
            dataAccess.GetBillsForUser(invalidGetBillsForUserRequest).Returns(invalidGetBillsForUserResponse);
            dataAccess.EditBill(validEditBillRequest).Returns(validEditBillResponse);
            dataAccess.EditBill(invalidEditBillRequest).Returns(invalidEditBillResponse);
            dataAccess.GetBillsForUserForMonth(validGetBillsForUserForMonthRequest)
                .Returns(validGetBillsForUserForMonthResponse);
            dataAccess.GetBillsForUserForMonth(invalidGetBillsForUserForMonthRequest)
                .Returns(invalidGetBillsForUserForMonthResponse);

            assembler.NewExportViewModel(ExportType.Csv, new List<BillProxy> { validBillProxy })
                .Returns(new ExportViewModel());

            orchestrator = new BillOrchestrator(assembler, dataAccess);
        }

        [TearDown]
        public void TearDown()
        {
            orchestrator = null;
            assembler = null;
            dataAccess = null;
            validViewModel = null;
            validAddBillRequest = null;
            validAddBillResponse = null;
            invalidAddBillRequest = null;
            invalidAddBillResponse = null;
            validDeleteBillRequest = null;
            validDeleteBillResponse = null;
            invalidDeleteBillRequest = null;
            invalidDeleteBillResponse = null;
            validGetBillRequest = null;
            validGetBillResponse = null;
            invalidGetBillRequest = null;
            invalidGetBillResponse = null;
            validBillProxy = null;
            invalidBillViewModel = null;
        }

        #endregion
    }
}