namespace MyMoney.API.Orchestrators.Tests.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Assemblers.Spending.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DataModels.Common;
    using DataModels.Spending;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Spending;
    using Orchestrators.Spending.Interfaces;

    using Proxies.Common;
    using Proxies.Spending;

    #endregion

    [TestFixture]
    [Category("API Orchestrators")]
    public class ExpenditureOrchestratorTests
    {
        private IExpenditureOrchestrator orchestrator;

        private IExpenditureAssembler assembler;

        private IExpenditureRepository repository;

        private GetExpenditureForUserForMonthRequest invalidGetExpenditureForUserForMonthRequest;

        private GetExpenditureForUserForMonthRequest validGetExpenditureForUserForMonthRequest;

        private DeleteExpenditureRequest invalidDeleteExpenditureRequest;

        private GetExpenditureForUserRequest invalidGetExpenditureForUserRequest;

        private GetExpenditureForUserRequest validGetExpenditureForUserRequest;

        private GetExpenditureRequest invalidGetExpenditureRequest;

        private GetExpenditureRequest validGetExpenditureRequest;

        private DeleteExpenditureRequest validDeleteExpenditureRequest;

        private EditExpenditureRequest invalidEditExpenditureRequest;

        private EditExpenditureRequest validEditExpenditureRequest;

        private ExpenditureProxy expenditureProxy;

        private ExpenditureDataModel validExpenditureDataModel;

        private Guid userId;

        private Guid expenditureId;

        private AddExpenditureRequest invalidAddExpenditureRequest;

        private AddExpenditureRequest validAddExpenditureRequest;

        private AddExpenditureResponse validAddExpenditureResponse;

        private DeleteExpenditureResponse validDeleteExpenditureResponse;

        private EditExpenditureResponse validEditExpenditureResponse;

        private IEnumerable<ExpenditureDataModel> validData;

        private GetExpenditureResponse validGetExpenditureResponse;

        private GetExpenditureForUserForMonthResponse validGetExpenditureForUserForMonthResponse;

        private GetExpenditureForUserResponse validGetExpenditureForUserResponse;

        [SetUp]
        public void SetUp()
        {
            userId = Guid.NewGuid();
            expenditureId = Guid.NewGuid();

            validData = new List<ExpenditureDataModel>();

            invalidDeleteExpenditureRequest = new DeleteExpenditureRequest();
            invalidEditExpenditureRequest = new EditExpenditureRequest();
            invalidGetExpenditureForUserForMonthRequest = new GetExpenditureForUserForMonthRequest();
            invalidGetExpenditureForUserRequest = new GetExpenditureForUserRequest();
            invalidGetExpenditureRequest = new GetExpenditureRequest();
            invalidAddExpenditureRequest = new AddExpenditureRequest();

            validExpenditureDataModel =
                new ExpenditureDataModel
                    {
                        Amount = 1,
                        Category =
                            new CategoryDataModel
                                {
                                    CreationTime = DateTime.Now,
                                    Id = Guid.NewGuid(),
                                    Name = "TEST"
                                },
                        CreationTime = DateTime.Now,
                        CategoryId = Guid.NewGuid(),
                        DateOccurred = DateTime.Now,
                        Description = "TEST",
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid()
                    };

            expenditureProxy = new ExpenditureProxy
                                   {
                                       Amount = 1.0,
                                       Category =
                                           new CategoryProxy { Id = Guid.NewGuid(), Name = "TEST" },
                                       CategoryId = Guid.NewGuid(),
                                       DateOccurred = DateTime.Now,
                                       Description = "TEST",
                                       Id = Guid.NewGuid(),
                                       UserId = Guid.NewGuid()
                                   };

            validDeleteExpenditureRequest =
                new DeleteExpenditureRequest { ExpenditureId = Guid.NewGuid(), Username = "TEST" };

            validGetExpenditureForUserForMonthRequest =
                new GetExpenditureForUserForMonthRequest { MonthNumber = 1, UserId = userId, Username = "TEST" };

            validAddExpenditureRequest =
                new AddExpenditureRequest { Expenditure = expenditureProxy, Username = "TEST" };

            validGetExpenditureForUserRequest = new GetExpenditureForUserRequest { UserId = userId, Username = "TEST" };

            validGetExpenditureRequest = new GetExpenditureRequest { ExpenditureId = expenditureId, Username = "TEST" };

            validEditExpenditureRequest =
                new EditExpenditureRequest { Expenditure = expenditureProxy, Username = "TEST" };

            validGetExpenditureForUserResponse =
                new GetExpenditureForUserResponse { Expenditure = new List<ExpenditureProxy> { expenditureProxy } };
            validGetExpenditureResponse = new GetExpenditureResponse { Expenditure = expenditureProxy };
            validAddExpenditureResponse = new AddExpenditureResponse { Expenditure = expenditureProxy };
            validEditExpenditureResponse = new EditExpenditureResponse { Expenditure = expenditureProxy };
            validDeleteExpenditureResponse = new DeleteExpenditureResponse { DeleteSuccess = true };
            validGetExpenditureForUserForMonthResponse =
                new GetExpenditureForUserForMonthResponse { Data = new List<ExpenditureProxy> { expenditureProxy } };

            assembler = Substitute.For<IExpenditureAssembler>();
            repository = Substitute.For<IExpenditureRepository>();

            repository.AddExpenditure(validExpenditureDataModel).Returns(validExpenditureDataModel);
            repository.AddExpenditure(null).Throws(new Exception("TEST"));

            repository.DeleteExpenditure(validDeleteExpenditureRequest.ExpenditureId).Returns(true);
            repository.DeleteExpenditure(invalidDeleteExpenditureRequest.ExpenditureId).Throws(new Exception("TEST"));

            repository.EditExpenditure(validExpenditureDataModel).Returns(validExpenditureDataModel);
            repository.EditExpenditure(null).Throws(new Exception("TEST"));

            repository.GetExpenditure(expenditureId).Returns(validExpenditureDataModel);
            repository.GetExpenditure(Guid.Empty).Throws(new Exception("TEST"));

            repository.GetExpenditureForUser(validGetExpenditureForUserRequest.UserId)
                .Returns(new List<ExpenditureDataModel> { validExpenditureDataModel });
            repository.GetExpenditureForUser(Guid.Empty).Throws(new Exception("TEST"));

            repository.GetExpenditureForUserForMonth(userId)
                .Returns(new List<ExpenditureDataModel> { validExpenditureDataModel });
            repository.GetExpenditureForUserForMonth(Guid.Empty).Throws(new Exception("TEST"));

            assembler.NewAddExpenditureResponse(validExpenditureDataModel, validAddExpenditureRequest.RequestReference)
                .Returns(validAddExpenditureResponse);

            assembler.NewDeleteExpenditureResponse(true, validDeleteExpenditureRequest.ExpenditureId)
                .Returns(validDeleteExpenditureResponse);

            assembler.NewEditExpenditureResponse(
                    validExpenditureDataModel,
                    validEditExpenditureRequest.RequestReference)
                .Returns(validEditExpenditureResponse);

            assembler.NewExpenditureDataModel(expenditureProxy).Returns(validExpenditureDataModel);

            assembler.NewGetExpenditureForUserForMonthResponse(
                    Arg.Any<List<ExpenditureDataModel>>(),
                    validGetExpenditureForUserForMonthRequest.RequestReference)
                .Returns(validGetExpenditureForUserForMonthResponse);

            assembler.NewGetExpenditureForUserResponse(
                    Arg.Any<List<ExpenditureDataModel>>(),
                    validGetExpenditureForUserRequest.RequestReference)
                .Returns(validGetExpenditureForUserResponse);

            assembler.NewDeleteExpenditureResponse(true, validDeleteExpenditureRequest.RequestReference)
                .Returns(validDeleteExpenditureResponse);

            assembler.NewGetExpenditureResponse(validExpenditureDataModel, validGetExpenditureRequest.RequestReference)
                .Returns(validGetExpenditureResponse);

            orchestrator = new ExpenditureOrchestrator(repository, assembler);
        }

        [TearDown]
        public void TearDown()
        {
            orchestrator = null;
            assembler = null;
            repository = null;
        }

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { orchestrator = new ExpenditureOrchestrator(null, assembler); });

            Assert.Throws<ArgumentNullException>(
                delegate { orchestrator = new ExpenditureOrchestrator(repository, null); });
        }

        [Test]
        public void DeleteExpenditure_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.DeleteExpenditure(validDeleteExpenditureRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteExpenditureResponse>(test);
            Assert.IsTrue(test.DeleteSuccess);
        }

        [Test]
        public void DeleteExpenditure_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.DeleteExpenditure(invalidDeleteExpenditureRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteExpenditureResponse>(test);
            Assert.IsFalse(test.DeleteSuccess);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetExpenditure_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetExpenditure(validGetExpenditureRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureResponse>(test);
            Assert.IsNotNull(test.Expenditure);
            Assert.IsTrue(test.Success);
        }

        [Test]
        public void GetExpenditure_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditure(invalidGetExpenditureRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureResponse>(test);
            Assert.IsNull(test.Expenditure);
            Assert.IsFalse(test.Success);
        }

        [Test]
        public void GetExpenditureForUser_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetExpenditureForUser(validGetExpenditureForUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureForUserResponse>(test);
            Assert.IsNotNull(test.Expenditure);
            Assert.AreEqual(1, test.Expenditure.Count);
            Assert.IsTrue(test.Success);
        }

        [Test]
        public void GetExpenditureForUser_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditureForUser(invalidGetExpenditureForUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureForUserResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetExpenditureForUserForMonth_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetExpenditureForUserForMonth(validGetExpenditureForUserForMonthRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureForUserForMonthResponse>(test);
            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Data);
            Assert.AreEqual(1, test.Data.Count());
        }

        [Test]
        public void GetExpenditureForUserForMonth_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditureForUserForMonth(invalidGetExpenditureForUserForMonthRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureForUserForMonthResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Data);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void AddExpenditure_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.AddExpenditure(validAddExpenditureRequest, "TEST").Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddExpenditureResponse>(test);
            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Expenditure);
        }

        [Test]
        public void AddExpenditure_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.AddExpenditure(invalidAddExpenditureRequest, "TEST").Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddExpenditureResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Expenditure);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void EditExpenditure_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.EditExpenditure(validEditExpenditureRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditExpenditureResponse>(test);
            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Expenditure);
        }

        [Test]
        public void EditExpenditure_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.EditExpenditure(invalidEditExpenditureRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditExpenditureResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Expenditure);
            Assert.AreEqual(1, test.Errors.Count);
        }
    }
}