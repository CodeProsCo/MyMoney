namespace MyMoney.Web.Orchestrators.Tests.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Saving.Interfaces;

    using DataAccess.Saving.Interfaces;

    using DTO.Request.Saving.Goal;
    using DTO.Response.Saving.Goal;

    using Helpers.Error.Interfaces;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Saving;
    using Orchestrators.Saving.Interfaces;

    using Proxies.Saving;

    using ViewModels.Saving.Goal;

    using Wrappers;

    #endregion

    [Category("Web Orchestrators")]
    [TestFixture]
    public class GoalOrchestratorTests
    {
        private const string validUsername = "TEST";

        #region Fields

        private IGoalAssembler assembler;

        private IGoalDataAccess dataAccess;

        private IErrorHelper errorHelper;

        private AddGoalRequest invalidAddGoalRequest;

        private AddGoalResponse invalidAddGoalResponse;

        private DeleteGoalRequest invalidDeleteGoalRequest;

        private DeleteGoalResponse invalidDeleteGoalResponse;

        private EditGoalRequest invalidEditGoalRequest;

        private EditGoalResponse invalidEditGoalResponse;

        private GetGoalRequest invalidGetGoalRequest;

        private GetGoalResponse invalidGetGoalResponse;

        private GetGoalsForUserRequest invalidGetGoalsForUserRequest;

        private GetGoalsForUserResponse invalidGetGoalsForUserResponse;

        private GoalViewModel invalidGoalViewModel;

        private IGoalOrchestrator orchestrator;

        private AddGoalRequest validAddGoalRequest;

        private AddGoalResponse validAddGoalResponse;

        private DeleteGoalRequest validDeleteGoalRequest;

        private DeleteGoalResponse validDeleteGoalResponse;

        private EditGoalRequest validEditGoalRequest;

        private EditGoalResponse validEditGoalResponse;

        private GetGoalRequest validGetGoalRequest;

        private GetGoalResponse validGetGoalResponse;

        private GetGoalsForUserRequest validGetGoalsForUserRequest;

        private GetGoalsForUserResponse validGetGoalsForUserResponse;

        private GoalProxy validGoalProxy;

        private ManageGoalsViewModel validManageGoalsViewModel;

        private GoalViewModel validViewModel;

        #endregion

        #region Methods

        [Test]
        public void AddGoal_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.AddGoal(invalidGoalViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<GoalViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void AddGoal_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.AddGoal(null, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<GoalViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void AddGoal_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.AddGoal(validViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<GoalViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { orchestrator = new GoalOrchestrator(null, assembler, errorHelper); });

            Assert.Throws<ArgumentNullException>(
                delegate { orchestrator = new GoalOrchestrator(dataAccess, null, errorHelper); });
        }

        [Test]
        public void DeleteGoal_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.DeleteGoal(invalidGoalViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.IsNotNull(test);
            Assert.IsFalse(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void DeleteGoal_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.DeleteGoal(Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.IsNotNull(test);
            Assert.IsFalse(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void DeleteGoal_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.DeleteGoal(validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void EditGoal_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.EditGoal(invalidGoalViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<GoalViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void EditGoal_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.EditGoal(null, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<GoalViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void EditGoal_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.EditGoal(validViewModel, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<GoalViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void GetGoal_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetGoal(invalidGoalViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<GoalViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetGoal_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetGoal(Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<GoalViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetGoal_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.GetGoal(validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<GoalViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [Test]
        public void GetGoalsForUser_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetGoalsForUser(invalidGoalViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ManageGoalsViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetGoalsForUser_NullParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetGoalsForUser(Guid.Empty, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ManageGoalsViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(1, test.Errors.Count);
        }

        [Test]
        public void GetGoalsForUser_ValidParams_ReturnsViewModel()
        {
            var test = orchestrator.GetGoalsForUser(validViewModel.Id, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ManageGoalsViewModel>>(test);
            Assert.IsNotNull(test);
            Assert.AreEqual(0, test.Errors.Count);
        }

        [SetUp]
        public void SetUp()
        {
            validViewModel = new GoalViewModel { Amount = 10, Id = Guid.NewGuid(), UserId = Guid.NewGuid() };

            validGoalProxy = new GoalProxy { Amount = 10, Id = Guid.NewGuid(), UserId = Guid.NewGuid() };

            validManageGoalsViewModel = new ManageGoalsViewModel();

            validDeleteGoalRequest = new DeleteGoalRequest { GoalId = validGoalProxy.Id };
            validDeleteGoalResponse = new DeleteGoalResponse { DeleteSuccess = true };
            validAddGoalRequest = new AddGoalRequest { Goal = validGoalProxy };
            validAddGoalResponse = new AddGoalResponse { Goal = validGoalProxy };
            validGetGoalRequest = new GetGoalRequest { GoalId = validGoalProxy.Id };
            validGetGoalResponse = new GetGoalResponse { Goal = validGoalProxy };
            validGetGoalsForUserRequest = new GetGoalsForUserRequest { UserId = validGoalProxy.Id };
            validGetGoalsForUserResponse =
                new GetGoalsForUserResponse { Goals = new List<GoalProxy> { validGoalProxy } };
            validEditGoalRequest = new EditGoalRequest { Goal = validGoalProxy };
            validEditGoalResponse = new EditGoalResponse { Goal = validGoalProxy };

            invalidGoalViewModel = new GoalViewModel { Id = Guid.NewGuid() };
            invalidAddGoalRequest = new AddGoalRequest();
            invalidAddGoalResponse = new AddGoalResponse { Errors = { new ResponseErrorWrapper() } };
            invalidGetGoalRequest = new GetGoalRequest();
            invalidGetGoalResponse = new GetGoalResponse { Errors = { new ResponseErrorWrapper() } };
            invalidDeleteGoalRequest = new DeleteGoalRequest();
            invalidDeleteGoalResponse = new DeleteGoalResponse { Errors = { new ResponseErrorWrapper() } };
            invalidGetGoalsForUserRequest = new GetGoalsForUserRequest();
            invalidGetGoalsForUserResponse = new GetGoalsForUserResponse { Errors = { new ResponseErrorWrapper() } };
            invalidEditGoalRequest = new EditGoalRequest();
            invalidEditGoalResponse = new EditGoalResponse { Errors = { new ResponseErrorWrapper() } };

            assembler = Substitute.For<IGoalAssembler>();
            dataAccess = Substitute.For<IGoalDataAccess>();

            assembler.NewAddGoalRequest(validViewModel, validUsername).Returns(validAddGoalRequest);
            assembler.NewAddGoalRequest(invalidGoalViewModel, validUsername).Returns(invalidAddGoalRequest);
            assembler.NewAddGoalRequest(null, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewDeleteGoalRequest(validViewModel.Id, validUsername).Returns(validDeleteGoalRequest);
            assembler.NewDeleteGoalRequest(invalidGoalViewModel.Id, validUsername).Returns(invalidDeleteGoalRequest);
            assembler.NewDeleteGoalRequest(Guid.Empty, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewGetGoalRequest(validViewModel.Id, validUsername).Returns(validGetGoalRequest);
            assembler.NewGetGoalRequest(invalidGoalViewModel.Id, validUsername).Returns(invalidGetGoalRequest);
            assembler.NewGetGoalRequest(Guid.Empty, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewGetGoalsForUserRequest(validViewModel.Id, validUsername).Returns(validGetGoalsForUserRequest);
            assembler.NewGetGoalsForUserRequest(invalidGoalViewModel.Id, validUsername)
                .Returns(invalidGetGoalsForUserRequest);
            assembler.NewGetGoalsForUserRequest(Guid.Empty, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewEditGoalRequest(validViewModel, validUsername).Returns(validEditGoalRequest);
            assembler.NewEditGoalRequest(invalidGoalViewModel, validUsername).Returns(invalidEditGoalRequest);
            assembler.NewEditGoalRequest(null, validUsername).Throws(new Exception("TEST EXCEPTION"));
            assembler.NewManageGoalsViewModel(new List<GoalProxy> { validGoalProxy })
                .Returns(validManageGoalsViewModel);

            dataAccess.AddGoal(validAddGoalRequest).Returns(validAddGoalResponse);
            dataAccess.AddGoal(invalidAddGoalRequest).Returns(invalidAddGoalResponse);
            dataAccess.DeleteGoal(validDeleteGoalRequest).Returns(validDeleteGoalResponse);
            dataAccess.DeleteGoal(invalidDeleteGoalRequest).Returns(invalidDeleteGoalResponse);
            dataAccess.GetGoal(validGetGoalRequest).Returns(validGetGoalResponse);
            dataAccess.GetGoal(invalidGetGoalRequest).Returns(invalidGetGoalResponse);
            dataAccess.GetGoalsForUser(validGetGoalsForUserRequest).Returns(validGetGoalsForUserResponse);
            dataAccess.GetGoalsForUser(invalidGetGoalsForUserRequest).Returns(invalidGetGoalsForUserResponse);
            dataAccess.EditGoal(validEditGoalRequest).Returns(validEditGoalResponse);
            dataAccess.EditGoal(invalidEditGoalRequest).Returns(invalidEditGoalResponse);

            errorHelper = Substitute.For<IErrorHelper>();

            errorHelper.Create(Arg.Any<Exception>(), Arg.Any<string>(), Arg.Any<Type>(), Arg.Any<string>())
                .Returns(new ResponseErrorWrapper());
            errorHelper.Create(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<Type>(), Arg.Any<string>())
                .Returns(new ResponseErrorWrapper());

            orchestrator = new GoalOrchestrator(dataAccess, assembler, errorHelper);
        }

        [TearDown]
        public void TearDown()
        {
            orchestrator = null;
            assembler = null;
            dataAccess = null;
            validViewModel = null;
            validAddGoalRequest = null;
            validAddGoalResponse = null;
            invalidAddGoalRequest = null;
            invalidAddGoalResponse = null;
            validDeleteGoalRequest = null;
            validDeleteGoalResponse = null;
            invalidDeleteGoalRequest = null;
            invalidDeleteGoalResponse = null;
            validGetGoalRequest = null;
            validGetGoalResponse = null;
            invalidGetGoalRequest = null;
            invalidGetGoalResponse = null;
            validGoalProxy = null;
            invalidGoalViewModel = null;
        }

        #endregion
    }
}