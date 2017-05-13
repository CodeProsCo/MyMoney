namespace MyMoney.API.Orchestrators.Tests.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Saving.Interfaces;

    using DataAccess.Saving.Interfaces;

    using DataModels.Saving;

    using DTO.Request.Saving.Goal;
    using DTO.Response.Saving.Goal;

    using Helpers.Error.Interfaces;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Saving;
    using Orchestrators.Saving.Interfaces;

    using Proxies.Saving;

    using Wrappers;

    #endregion

    [TestFixture]
    [Category("API Orchestrators")]
    public class GoalOrchestratorTests
    {
        private IGoalOrchestrator orchestrator;

        private IGoalAssembler assembler;

        private IGoalRepository repository;

        private DeleteGoalRequest invalidDeleteGoalRequest;

        private GetGoalsForUserRequest invalidGetGoalsForUserRequest;

        private GetGoalsForUserRequest validGetGoalsForUserRequest;

        private GetGoalRequest invalidGetGoalRequest;

        private GetGoalRequest validGetGoalRequest;

        private DeleteGoalRequest validDeleteGoalRequest;

        private EditGoalRequest invalidEditGoalRequest;

        private EditGoalRequest validEditGoalRequest;

        private GoalProxy expenditureProxy;

        private GoalDataModel validGoalDataModel;

        private Guid userId;

        private Guid expenditureId;

        private AddGoalRequest invalidAddGoalRequest;

        private AddGoalRequest validAddGoalRequest;

        private AddGoalResponse validAddGoalResponse;

        private DeleteGoalResponse validDeleteGoalResponse;

        private EditGoalResponse validEditGoalResponse;

        private IEnumerable<GoalDataModel> validData;

        private GetGoalResponse validGetGoalResponse;

        private GetGoalsForUserResponse validGetGoalsForUserResponse;

        private IErrorHelper errorHelper;

        [SetUp]
        public void SetUp()
        {
            userId = Guid.NewGuid();
            expenditureId = Guid.NewGuid();

            validData = new List<GoalDataModel>();

            invalidDeleteGoalRequest = new DeleteGoalRequest();
            invalidEditGoalRequest = new EditGoalRequest();
            invalidGetGoalsForUserRequest = new GetGoalsForUserRequest();
            invalidGetGoalRequest = new GetGoalRequest();
            invalidAddGoalRequest = new AddGoalRequest();

            validGoalDataModel = new GoalDataModel
                                     {
                                         Amount = 1,
                                         CreationTime = DateTime.Now,
                                         Id = Guid.NewGuid(),
                                         UserId = Guid.NewGuid()
                                     };

            expenditureProxy = new GoalProxy { Amount = 1.0, Id = Guid.NewGuid(), UserId = Guid.NewGuid() };

            validDeleteGoalRequest = new DeleteGoalRequest { GoalId = Guid.NewGuid(), Username = "TEST" };

            validAddGoalRequest = new AddGoalRequest { Goal = expenditureProxy, Username = "TEST" };

            validGetGoalsForUserRequest = new GetGoalsForUserRequest { UserId = userId, Username = "TEST" };

            validGetGoalRequest = new GetGoalRequest { GoalId = expenditureId, Username = "TEST" };

            validEditGoalRequest = new EditGoalRequest { Goal = expenditureProxy, Username = "TEST" };

            validGetGoalsForUserResponse =
                new GetGoalsForUserResponse { Goals = new List<GoalProxy> { expenditureProxy } };
            validGetGoalResponse = new GetGoalResponse { Goal = expenditureProxy };
            validAddGoalResponse = new AddGoalResponse { Goal = expenditureProxy };
            validEditGoalResponse = new EditGoalResponse { Goal = expenditureProxy };
            validDeleteGoalResponse = new DeleteGoalResponse { DeleteSuccess = true };

            assembler = Substitute.For<IGoalAssembler>();
            repository = Substitute.For<IGoalRepository>();
            errorHelper = Substitute.For<IErrorHelper>();

            errorHelper.Create(Arg.Any<Exception>(), Arg.Any<string>(), Arg.Any<Type>(), Arg.Any<string>())
                .Returns(new ResponseErrorWrapper());
            errorHelper.Create(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<Type>(), Arg.Any<string>())
                .Returns(new ResponseErrorWrapper());

            repository.AddGoal(validGoalDataModel).Returns(validGoalDataModel);
            repository.AddGoal(null).Throws(new Exception("TEST"));

            repository.DeleteGoal(validDeleteGoalRequest.GoalId).Returns(true);
            repository.DeleteGoal(invalidDeleteGoalRequest.GoalId).Throws(new Exception("TEST"));

            repository.EditGoal(validGoalDataModel).Returns(validGoalDataModel);
            repository.EditGoal(null).Throws(new Exception("TEST"));

            repository.GetGoal(expenditureId).Returns(validGoalDataModel);
            repository.GetGoal(Guid.Empty).Throws(new Exception("TEST"));

            repository.GetGoalsForUser(validGetGoalsForUserRequest.UserId)
                .Returns(new List<GoalDataModel> { validGoalDataModel });
            repository.GetGoalsForUser(Guid.Empty).Throws(new Exception("TEST"));

            assembler.NewAddGoalResponse(validGoalDataModel, validAddGoalRequest.RequestReference)
                .Returns(validAddGoalResponse);

            assembler.NewDeleteGoalResponse(true, validDeleteGoalRequest.GoalId).Returns(validDeleteGoalResponse);

            assembler.NewEditGoalResponse(validGoalDataModel, validEditGoalRequest.RequestReference)
                .Returns(validEditGoalResponse);

            assembler.NewGoalDataModel(expenditureProxy).Returns(validGoalDataModel);

            assembler.NewGetGoalsForUserResponse(
                    Arg.Any<List<GoalDataModel>>(),
                    validGetGoalsForUserRequest.RequestReference)
                .Returns(validGetGoalsForUserResponse);

            assembler.NewDeleteGoalResponse(true, validDeleteGoalRequest.RequestReference)
                .Returns(validDeleteGoalResponse);

            assembler.NewGetGoalResponse(validGoalDataModel, validGetGoalRequest.RequestReference)
                .Returns(validGetGoalResponse);

            orchestrator = new GoalOrchestrator(assembler, repository, errorHelper);
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
            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new GoalOrchestrator(null, repository, errorHelper); });

            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new GoalOrchestrator(assembler, null, errorHelper); });
        }

        [Test]
        public void DeleteGoal_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.DeleteGoal(validDeleteGoalRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteGoalResponse>(test);
            Assert.IsTrue(test.DeleteSuccess);
        }

        [Test]
        public void DeleteGoal_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.DeleteGoal(invalidDeleteGoalRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteGoalResponse>(test);
            Assert.IsFalse(test.DeleteSuccess);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetGoal_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetGoal(validGetGoalRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetGoalResponse>(test);
            Assert.IsNotNull(test.Goal);
            Assert.IsTrue(test.Success);
        }

        [Test]
        public void GetGoal_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetGoal(invalidGetGoalRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetGoalResponse>(test);
            Assert.IsNull(test.Goal);
            Assert.IsFalse(test.Success);
        }

        [Test]
        public void GetGoalsForUser_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetGoalsForUser(validGetGoalsForUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetGoalsForUserResponse>(test);
            Assert.IsNotNull(test.Goals);
            Assert.AreEqual(1, test.Goals.Count);
            Assert.IsTrue(test.Success);
        }

        [Test]
        public void GetGoalsForUser_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetGoalsForUser(invalidGetGoalsForUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetGoalsForUserResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void AddGoal_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.AddGoal(validAddGoalRequest, "TEST").Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddGoalResponse>(test);
            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Goal);
        }

        [Test]
        public void AddGoal_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.AddGoal(invalidAddGoalRequest, "TEST").Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddGoalResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Goal);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void EditGoal_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.EditGoal(validEditGoalRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditGoalResponse>(test);
            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Goal);
        }

        [Test]
        public void EditGoal_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.EditGoal(invalidEditGoalRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditGoalResponse>(test);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Goal);
            Assert.AreEqual(1, test.Errors.Count);
        }
    }
}