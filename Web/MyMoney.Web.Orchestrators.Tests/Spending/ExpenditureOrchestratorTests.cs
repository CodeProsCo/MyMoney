namespace MyMoney.Web.Orchestrators.Tests.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    using Helpers.Error.Interfaces;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Spending;
    using Orchestrators.Spending.Interfaces;

    using Proxies.Common;
    using Proxies.Spending;

    using ViewModels.Common;
    using ViewModels.Enum;
    using ViewModels.Spending.Expenditure;

    using Wrappers;

    #endregion

    [Category("Web Orchestrators")]
    [TestFixture]
    public class ExpenditureOrchestratorTests
    {
        #region Constants

        private const string validUsername = "TEST";

        #endregion

        #region Fields

        private IExpenditureAssembler assembler;

        private IExpenditureDataAccess dataAccess;

        private AddExpenditureRequest invalidAddExpenditureRequest;

        private AddExpenditureResponse invalidAddExpenditureResponse;

        private ExpenditureViewModel invalidExpenditureViewModel;

        private DeleteExpenditureRequest invalidDeleteExpenditureRequest;

        private DeleteExpenditureResponse invalidDeleteExpenditureResponse;

        private EditExpenditureRequest invalidEditExpenditureRequest;

        private EditExpenditureResponse invalidEditExpenditureResponse;

        private GetExpenditureRequest invalidGetExpenditureRequest;

        private GetExpenditureResponse invalidGetExpenditureResponse;

        private GetExpenditureForUserForMonthRequest invalidGetExpenditureForUserForMonthRequest;

        private GetExpenditureForUserForMonthResponse invalidGetExpenditureForUserForMonthResponse;

        private GetExpenditureForUserRequest invalidGetExpenditureForUserRequest;

        private GetExpenditureForUserResponse invalidGetExpenditureForUserResponse;

        private IExpenditureOrchestrator orchestrator;

        private AddExpenditureRequest validAddExpenditureRequest;

        private AddExpenditureResponse validAddExpenditureResponse;

        private ExpenditureProxy validExpenditureProxy;

        private DeleteExpenditureRequest validDeleteExpenditureRequest;

        private DeleteExpenditureResponse validDeleteExpenditureResponse;

        private EditExpenditureRequest validEditExpenditureRequest;

        private EditExpenditureResponse validEditExpenditureResponse;

        private GetExpenditureRequest validGetExpenditureRequest;

        private GetExpenditureResponse validGetExpenditureResponse;

        private GetExpenditureForUserForMonthRequest validGetExpenditureForUserForMonthRequest;

        private GetExpenditureForUserForMonthResponse validGetExpenditureForUserForMonthResponse;

        private GetExpenditureForUserRequest validGetExpenditureForUserRequest;

        private GetExpenditureForUserResponse validGetExpenditureForUserResponse;

        private TrackExpenditureViewModel validTrackExpenditureViewModel;

        private ExpenditureViewModel validViewModel;

        private IErrorHelper errorHelper;

        #endregion

        #region Methods

        [Test]
        public void AddExpenditure_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.AddExpenditure(invalidExpenditureViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void AddExpenditure_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.AddExpenditure(null, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void ExportExpenditure_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.ExportExpenditure(ExportType.Csv, validUsername, validViewModel.Id).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExportViewModel>>(test);
        }

        [Test]
        public void ExportExpenditure_InvalidParams_ReturnsResponse()
        {
            var test = orchestrator.ExportExpenditure(ExportType.Csv, validUsername, invalidExpenditureViewModel.Id)
                .Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExportViewModel>>(test);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void ExportExpenditure_ThrowsException_ReturnsResponse()
        {
            var test = orchestrator.ExportExpenditure(ExportType.Json, validUsername, validViewModel.Id).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExportViewModel>>(test);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void AddExpenditure_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.AddExpenditure(validViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { orchestrator = new ExpenditureOrchestrator(null, dataAccess, errorHelper); });

            Assert.Throws<ArgumentNullException>(
                delegate { orchestrator = new ExpenditureOrchestrator(assembler, null, errorHelper); });
        }

        [Test]
        public void DeleteExpenditure_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.DeleteExpenditure(invalidExpenditureViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.IsNotNull(test);
            Assert.IsFalse(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void DeleteExpenditure_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.DeleteExpenditure(Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.IsNotNull(test);
            Assert.IsFalse(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void DeleteExpenditure_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.DeleteExpenditure(validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void EditExpenditure_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.EditExpenditure(invalidExpenditureViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void EditExpenditure_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.EditExpenditure(null, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void EditExpenditure_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.EditExpenditure(validViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void GetExpenditure_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditure(invalidExpenditureViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetExpenditure_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditure(Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetExpenditure_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.GetExpenditure(validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void GetExpenditureForUser_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditureForUser(invalidExpenditureViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<TrackExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetExpenditureForUser_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditureForUser(Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<TrackExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetExpenditureForUser_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.GetExpenditureForUser(validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<TrackExpenditureViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void GetExpenditureForUserForMonth_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditureForUserForMonth(1, invalidExpenditureViewModel.Id, validUsername)
                .Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<ExpenditureViewModel>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetExpenditureForUserForMonth_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditureForUserForMonth(1, Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<ExpenditureViewModel>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetExpenditureForUserForMonth_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.GetExpenditureForUserForMonth(1, validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<ExpenditureViewModel>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [SetUp]
        public void SetUp()
        {
            validViewModel = new ExpenditureViewModel
            {
                Amount = 10,
                Category = "TEST",
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            validExpenditureProxy = new ExpenditureProxy
            {
                Amount = 10,
                Category =
                                                new CategoryProxy
                                                {
                                                    Id = Guid.NewGuid(),
                                                    Name = "TEST"
                                                },
                CategoryId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            validTrackExpenditureViewModel = new TrackExpenditureViewModel();

            validDeleteExpenditureRequest = new DeleteExpenditureRequest { ExpenditureId = validExpenditureProxy.Id };
            validDeleteExpenditureResponse = new DeleteExpenditureResponse { DeleteSuccess = true };
            validAddExpenditureRequest = new AddExpenditureRequest { Expenditure = validExpenditureProxy };
            validAddExpenditureResponse = new AddExpenditureResponse { Expenditure = validExpenditureProxy };
            validGetExpenditureRequest = new GetExpenditureRequest { ExpenditureId = validExpenditureProxy.Id };
            validGetExpenditureResponse = new GetExpenditureResponse { Expenditure = validExpenditureProxy };
            validGetExpenditureForUserRequest = new GetExpenditureForUserRequest { UserId = validExpenditureProxy.Id };
            validGetExpenditureForUserResponse =
                new GetExpenditureForUserResponse
                {
                    Expenditure = new List<ExpenditureProxy> { validExpenditureProxy }
                };
            validEditExpenditureRequest = new EditExpenditureRequest { Expenditure = validExpenditureProxy };
            validEditExpenditureResponse = new EditExpenditureResponse { Expenditure = validExpenditureProxy };
            validGetExpenditureForUserForMonthRequest =
                new GetExpenditureForUserForMonthRequest { UserId = validExpenditureProxy.Id };
            validGetExpenditureForUserForMonthResponse =
                new GetExpenditureForUserForMonthResponse
                {
                    Data =
                            new List<ExpenditureProxy> { validExpenditureProxy }
                };

            invalidExpenditureViewModel = new ExpenditureViewModel { Id = Guid.NewGuid() };
            invalidAddExpenditureRequest = new AddExpenditureRequest();
            invalidAddExpenditureResponse = new AddExpenditureResponse { Errors = { new ResponseErrorWrapper() } };
            invalidGetExpenditureRequest = new GetExpenditureRequest();
            invalidGetExpenditureResponse = new GetExpenditureResponse { Errors = { new ResponseErrorWrapper() } };
            invalidDeleteExpenditureRequest = new DeleteExpenditureRequest();
            invalidDeleteExpenditureResponse =
                new DeleteExpenditureResponse { Errors = { new ResponseErrorWrapper() } };
            invalidGetExpenditureForUserRequest = new GetExpenditureForUserRequest();
            invalidGetExpenditureForUserResponse =
                new GetExpenditureForUserResponse { Errors = { new ResponseErrorWrapper() } };
            invalidEditExpenditureRequest = new EditExpenditureRequest();
            invalidEditExpenditureResponse = new EditExpenditureResponse { Errors = { new ResponseErrorWrapper() } };
            invalidGetExpenditureForUserForMonthRequest = new GetExpenditureForUserForMonthRequest();
            invalidGetExpenditureForUserForMonthResponse =
                new GetExpenditureForUserForMonthResponse { Errors = { new ResponseErrorWrapper() } };

            assembler = Substitute.For<IExpenditureAssembler>();
            dataAccess = Substitute.For<IExpenditureDataAccess>();
            errorHelper = Substitute.For<IErrorHelper>();

            errorHelper.Create(Arg.Any<Exception>(), Arg.Any<string>(), Arg.Any<Type>(), Arg.Any<string>())
                .Returns(new ResponseErrorWrapper());
            errorHelper.Create(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<Type>(), Arg.Any<string>())
                .Returns(new ResponseErrorWrapper());

            assembler.NewAddExpenditureRequest(validViewModel, validUsername).Returns(validAddExpenditureRequest);
            assembler.NewAddExpenditureRequest(invalidExpenditureViewModel, validUsername)
                .Returns(invalidAddExpenditureRequest);
            assembler.NewAddExpenditureRequest(null, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewExpenditureViewModel(validAddExpenditureResponse).Returns(validViewModel);
            assembler.NewExpenditureViewModel(validEditExpenditureResponse).Returns(validViewModel);
            assembler.NewDeleteExpenditureRequest(validViewModel.Id, validUsername)
                .Returns(validDeleteExpenditureRequest);
            assembler.NewDeleteExpenditureRequest(invalidExpenditureViewModel.Id, validUsername)
                .Returns(invalidDeleteExpenditureRequest);
            assembler.NewDeleteExpenditureRequest(Guid.Empty, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewGetExpenditureRequest(validViewModel.Id, validUsername).Returns(validGetExpenditureRequest);
            assembler.NewGetExpenditureRequest(invalidExpenditureViewModel.Id, validUsername)
                .Returns(invalidGetExpenditureRequest);
            assembler.NewGetExpenditureRequest(Guid.Empty, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewGetExpenditureForUserRequest(validViewModel.Id, validUsername)
                .Returns(validGetExpenditureForUserRequest);
            assembler.NewGetExpenditureForUserRequest(invalidExpenditureViewModel.Id, validUsername)
                .Returns(invalidGetExpenditureForUserRequest);
            assembler.NewGetExpenditureForUserRequest(Guid.Empty, validUsername)
                .Throws(new Exception("TEST EXCEPTION"));
            assembler.NewEditExpenditureRequest(validViewModel, validUsername).Returns(validEditExpenditureRequest);
            assembler.NewEditExpenditureRequest(invalidExpenditureViewModel, validUsername)
                .Returns(invalidEditExpenditureRequest);
            assembler.NewEditExpenditureRequest(null, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewGetExpenditureForUserForMonthRequest(1, validViewModel.Id, validUsername)
                .Returns(validGetExpenditureForUserForMonthRequest);
            assembler.NewGetExpenditureForUserForMonthRequest(1, invalidExpenditureViewModel.Id, validUsername)
                .Returns(invalidGetExpenditureForUserForMonthRequest);
            assembler.NewTrackExpenditureViewModel(validGetExpenditureForUserResponse)
                .Returns(validTrackExpenditureViewModel);
            assembler.NewExportViewModel(Arg.Any<IList<ExpenditureProxy>>(), ExportType.Json)
                .Throws(new Exception("TEST"));

            dataAccess.AddExpenditure(validAddExpenditureRequest).Returns(validAddExpenditureResponse);
            dataAccess.AddExpenditure(invalidAddExpenditureRequest).Returns(invalidAddExpenditureResponse);
            dataAccess.DeleteExpenditure(validDeleteExpenditureRequest).Returns(validDeleteExpenditureResponse);
            dataAccess.DeleteExpenditure(invalidDeleteExpenditureRequest).Returns(invalidDeleteExpenditureResponse);
            dataAccess.GetExpenditure(validGetExpenditureRequest).Returns(validGetExpenditureResponse);
            dataAccess.GetExpenditure(invalidGetExpenditureRequest).Returns(invalidGetExpenditureResponse);
            dataAccess.GetExpenditureForUser(validGetExpenditureForUserRequest)
                .Returns(validGetExpenditureForUserResponse);
            dataAccess.GetExpenditureForUser(invalidGetExpenditureForUserRequest)
                .Returns(invalidGetExpenditureForUserResponse);
            dataAccess.EditExpenditure(validEditExpenditureRequest).Returns(validEditExpenditureResponse);
            dataAccess.EditExpenditure(invalidEditExpenditureRequest).Returns(invalidEditExpenditureResponse);
            dataAccess.GetExpenditureForUserForMonth(validGetExpenditureForUserForMonthRequest)
                .Returns(validGetExpenditureForUserForMonthResponse);
            dataAccess.GetExpenditureForUserForMonth(invalidGetExpenditureForUserForMonthRequest)
                .Returns(invalidGetExpenditureForUserForMonthResponse);

            assembler.NewExportViewModel(new List<ExpenditureProxy> { validExpenditureProxy }, ExportType.Csv)
                .Returns(new ExportViewModel());

            orchestrator = new ExpenditureOrchestrator(assembler, dataAccess, errorHelper);
        }

        [TearDown]
        public void TearDown()
        {
            orchestrator = null;
            assembler = null;
            dataAccess = null;
            validViewModel = null;
            validAddExpenditureRequest = null;
            validAddExpenditureResponse = null;
            invalidAddExpenditureRequest = null;
            invalidAddExpenditureResponse = null;
            validDeleteExpenditureRequest = null;
            validDeleteExpenditureResponse = null;
            invalidDeleteExpenditureRequest = null;
            invalidDeleteExpenditureResponse = null;
            validGetExpenditureRequest = null;
            validGetExpenditureResponse = null;
            invalidGetExpenditureRequest = null;
            invalidGetExpenditureResponse = null;
            validExpenditureProxy = null;
            invalidExpenditureViewModel = null;
        }

        #endregion
    }
}