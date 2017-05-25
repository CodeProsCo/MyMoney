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

    using DataTransformers.Spending.Interfaces;

    using DTO.Request.Spending.Bill;
    using DTO.Response.Spending.Bill;

    using Helpers.Error.Interfaces;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Spending;
    using Orchestrators.Spending.Interfaces;

    using Proxies.Common;
    using Proxies.Spending;

    using Wrappers;

    #endregion

    [TestFixture]
    [Category("API Orchestrators")]
    public class BillOrchestratorTests
    {
        private IBillOrchestrator orchestrator;

        private IBillAssembler assembler;

        private IBillRepository repository;

        private IBillDataTransformer dataTransformer;

        private GetBillsForUserForMonthRequest invalidGetBillsForUserForMonthRequest;

        private GetBillsForUserForMonthRequest validGetBillsForUserForMonthRequest;

        private DeleteBillRequest invalidDeleteBillRequest;

        private GetBillsForUserRequest invalidGetBillsForUserRequest;

        private GetBillsForUserRequest validGetBillsForUserRequest;

        private GetBillRequest invalidGetBillRequest;

        private GetBillRequest validGetBillRequest;

        private DeleteBillRequest validDeleteBillRequest;

        private EditBillRequest invalidEditBillRequest;

        private EditBillRequest validEditBillRequest;

        private BillProxy expenditureProxy;

        private BillDataModel validBillDataModel;

        private Guid userId;

        private Guid expenditureId;

        private AddBillRequest invalidAddBillRequest;

        private AddBillRequest validAddBillRequest;

        private AddBillResponse validAddBillResponse;

        private DeleteBillResponse validDeleteBillResponse;

        private EditBillResponse validEditBillResponse;

        private IEnumerable<BillDataModel> validData;

        private GetBillResponse validGetBillResponse;

        private GetBillsForUserForMonthResponse validGetBillsForUserForMonthResponse;

        private GetBillsForUserResponse validGetBillsForUserResponse;

        private IErrorHelper errorHelper;

        [SetUp]
        public void SetUp()
        {
            userId = Guid.NewGuid();
            expenditureId = Guid.NewGuid();

            validData = new List<BillDataModel>();

            invalidDeleteBillRequest = new DeleteBillRequest();
            invalidEditBillRequest = new EditBillRequest();
            invalidGetBillsForUserForMonthRequest = new GetBillsForUserForMonthRequest();
            invalidGetBillsForUserRequest = new GetBillsForUserRequest();
            invalidGetBillRequest = new GetBillRequest();
            invalidAddBillRequest = new AddBillRequest();

            validBillDataModel =
                new BillDataModel
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
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid()
                };

            expenditureProxy = new BillProxy
            {
                Amount = 1.0,
                Category =
                                           new CategoryProxy { Id = Guid.NewGuid(), Name = "TEST" },
                CategoryId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            };

            validDeleteBillRequest =
                new DeleteBillRequest { BillId = Guid.NewGuid(), Username = "TEST" };

            validGetBillsForUserForMonthRequest =
                new GetBillsForUserForMonthRequest { MonthNumber = 1, UserId = userId, Username = "TEST" };

            validAddBillRequest =
                new AddBillRequest { Bill = expenditureProxy, Username = "TEST" };

            validGetBillsForUserRequest = new GetBillsForUserRequest { UserId = userId, Username = "TEST" };

            validGetBillRequest = new GetBillRequest { BillId = expenditureId, Username = "TEST" };

            validEditBillRequest =
                new EditBillRequest { Bill = expenditureProxy, Username = "TEST" };

            validGetBillsForUserResponse =
                new GetBillsForUserResponse { Bills = new List<BillProxy> { expenditureProxy } };
            validGetBillResponse = new GetBillResponse { Bill = expenditureProxy };
            validAddBillResponse = new AddBillResponse { Bill = expenditureProxy };
            validEditBillResponse = new EditBillResponse { Bill = expenditureProxy };
            validDeleteBillResponse = new DeleteBillResponse { DeleteSuccess = true };
            validGetBillsForUserForMonthResponse =
                new GetBillsForUserForMonthResponse { Data = new List<KeyValuePair<DateTime, double>> { new KeyValuePair<DateTime, double>(DateTime.Now, 1.0) } };

            assembler = Substitute.For<IBillAssembler>();
            repository = Substitute.For<IBillRepository>();
            dataTransformer = Substitute.For<IBillDataTransformer>();

            repository.AddBill(validBillDataModel).Returns(validBillDataModel);
            repository.AddBill(null).Throws(new Exception("TEST"));

            repository.DeleteBill(validDeleteBillRequest.BillId).Returns(true);
            repository.DeleteBill(invalidDeleteBillRequest.BillId).Throws(new Exception("TEST"));

            repository.EditBill(validBillDataModel).Returns(validBillDataModel);
            repository.EditBill(null).Throws(new Exception("TEST"));

            repository.GetBill(expenditureId).Returns(validBillDataModel);
            repository.GetBill(Guid.Empty).Throws(new Exception("TEST"));

            repository.GetBillsForUser(validGetBillsForUserRequest.UserId)
                .Returns(new List<BillDataModel> { validBillDataModel });
            repository.GetBillsForUser(Guid.Empty).Throws(new Exception("TEST"));

            dataTransformer.GetOutgoingBillsForMonth(Arg.Any<int>(), Arg.Any<List<BillDataModel>>())
                .Returns(
                    new List<KeyValuePair<DateTime, double>> { new KeyValuePair<DateTime, double>(DateTime.Now, 1.0) });

            dataTransformer.GetBillCategoryChartData(Arg.Any<List<BillDataModel>>())
                .Returns(new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>() });

            assembler.NewAddBillResponse(validBillDataModel, validAddBillRequest.RequestReference)
                .Returns(validAddBillResponse);

            assembler.NewDeleteBillResponse(true, validDeleteBillRequest.BillId)
                .Returns(validDeleteBillResponse);

            assembler.NewEditBillResponse(
                    validBillDataModel,
                    validEditBillRequest.RequestReference)
                .Returns(validEditBillResponse);

            assembler.NewBillDataModel(expenditureProxy).Returns(validBillDataModel);

            assembler.NewGetBillsForUserForMonthResponse(
                    Arg.Any<List<KeyValuePair<DateTime, double>>>(),
                    validGetBillsForUserForMonthRequest.RequestReference)
                .Returns(validGetBillsForUserForMonthResponse);

            assembler.NewGetBillsForUserResponse(
                    Arg.Any<List<BillDataModel>>(),
                    validGetBillsForUserRequest.RequestReference)
                .Returns(validGetBillsForUserResponse);

            assembler.NewDeleteBillResponse(true, validDeleteBillRequest.RequestReference)
                .Returns(validDeleteBillResponse);

            assembler.NewGetBillResponse(validBillDataModel, validGetBillRequest.RequestReference)
                .Returns(validGetBillResponse);

            errorHelper = Substitute.For<IErrorHelper>();

            errorHelper.Create(Arg.Any<Exception>(), Arg.Any<string>(), Arg.Any<Type>(), Arg.Any<string>())
                .Returns(new ResponseErrorWrapper());
            errorHelper.Create(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<Type>(), Arg.Any<string>())
                .Returns(new ResponseErrorWrapper());

            orchestrator = new BillOrchestrator(assembler, repository, dataTransformer, errorHelper);
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
                delegate { orchestrator = new BillOrchestrator(null, repository, dataTransformer, errorHelper); });

            Assert.Throws<ArgumentNullException>(
                delegate { orchestrator = new BillOrchestrator(assembler, null, dataTransformer, errorHelper); });


            Assert.Throws<ArgumentNullException>(
                delegate { orchestrator = new BillOrchestrator(assembler, repository, null, errorHelper); });
        }

        [Test]
        public void DeleteBill_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.DeleteBill(validDeleteBillRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteBillResponse>(test);
            Assert.IsTrue(test.DeleteSuccess);
        }

        [Test]
        public void DeleteBill_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.DeleteBill(invalidDeleteBillRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteBillResponse>(test);
            Assert.IsFalse(test.DeleteSuccess);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetBill_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetBill(validGetBillRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillResponse>(test);
            Assert.IsNotNull(test.Bill);
            Assert.IsTrue(test.Success);
        }

        [Test]
        public void GetBill_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBill(invalidGetBillRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillResponse>(test);
            Assert.IsNull(test.Bill);
            Assert.IsFalse(test.Success);
        }

        [Test]
        public void GetBillsForUser_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetBillsForUser(validGetBillsForUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillsForUserResponse>(test);
            Assert.IsNotNull(test.Bills);
            Assert.AreEqual(1, test.Bills.Count);
            Assert.IsTrue(test.Success);
        }

        [Test]
        public void GetBillsForUser_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillsForUser(invalidGetBillsForUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillsForUserResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetBillsForUserForMonth_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetBillsForUserForMonth(validGetBillsForUserForMonthRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillsForUserForMonthResponse>(test);
            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Data);
            Assert.AreEqual(1, test.Data.Count());
        }

        [Test]
        public void GetBillsForUserForMonth_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillsForUserForMonth(invalidGetBillsForUserForMonthRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillsForUserForMonthResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Data);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void AddBill_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.AddBill(validAddBillRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddBillResponse>(test);
            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Bill);
        }

        [Test]
        public void AddBill_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.AddBill(invalidAddBillRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddBillResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Bill);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void EditBill_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.EditBill(validEditBillRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditBillResponse>(test);
            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Bill);
        }

        [Test]
        public void EditBill_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.EditBill(invalidEditBillRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditBillResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Bill);
            Assert.AreEqual(1, test.Errors.Count);
        }
    }
}