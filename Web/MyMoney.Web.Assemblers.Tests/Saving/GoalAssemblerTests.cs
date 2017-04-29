namespace MyMoney.Web.Assemblers.Tests.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Assemblers.Saving;
    using Assemblers.Saving.Interfaces;

    using DTO.Request.Saving.Goal;

    using NUnit.Framework;

    using Proxies.Saving;

    using ViewModels.Saving.Goal;

    #endregion

    [TestFixture]
    public class GoalAssemblerTests
    {
        private IGoalAssembler assembler;

        private const string ValidUsername = "TEST";

        private GoalViewModel validViewModel;

        private Guid validGoalId;

        private IList<GoalProxy> validGoals;

        [SetUp]
        public void SetUp()
        {
            validGoalId = Guid.NewGuid();


            validViewModel = new GoalViewModel
            {
                Amount = 1,
                Complete = true,
                EndDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "TEST",
                StartDate = DateTime.MaxValue,
                UserId = Guid.NewGuid()
            };

            validGoals = new List<GoalProxy>
                             {
                                 new GoalProxy
                                     {
                                         Amount = 1,
                                         Complete = true,
                                         EndDate = DateTime.Now,
                                         Id = Guid.NewGuid(),
                                         Name = "TEST",
                                         StartDate = DateTime.Now,
                                         UserId = Guid.NewGuid()
                                     }
                             };

            assembler = new GoalAssembler();
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
        }

        [Test]
        public void NewEditGoalRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewEditGoalRequest(validViewModel, ValidUsername);

            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Goal);

            Assert.AreNotEqual(Guid.Empty, test.RequestReference);

            Assert.IsInstanceOf<EditGoalRequest>(test);
        }

        [Test]
        public void NewEditGoalRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewEditGoalRequest(null, ValidUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewEditGoalRequest(validViewModel, string.Empty); });
        }

        [Test]
        public void NewAddGoalRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewAddGoalRequest(validViewModel, ValidUsername);

            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Goal);

            Assert.AreNotEqual(Guid.Empty, test.RequestReference);

            Assert.IsInstanceOf<AddGoalRequest>(test);
        }

        [Test]
        public void NewGetGoalRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetGoalRequest(validGoalId, ValidUsername);

            Assert.IsNotNull(test);

            Assert.AreEqual(validGoalId, test.GoalId);

            Assert.AreNotEqual(Guid.Empty, test.RequestReference);

            Assert.IsInstanceOf<GetGoalRequest>(test);
        }

        [Test]
        public void NewGetGoalRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewGetGoalRequest(Guid.Empty, ValidUsername); });

            Assert.Throws<ArgumentNullException>(delegate { assembler.NewGetGoalRequest(validGoalId, string.Empty); });
        }

        [Test]
        public void NewDeleteGoalRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewDeleteGoalRequest(validGoalId, ValidUsername);

            Assert.IsNotNull(test);

            Assert.AreEqual(validGoalId, test.GoalId);

            Assert.AreNotEqual(Guid.Empty, test.RequestReference);

            Assert.IsInstanceOf<DeleteGoalRequest>(test);
        }

        [Test]
        public void NewDeleteGoalRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewDeleteGoalRequest(Guid.Empty, ValidUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewDeleteGoalRequest(validGoalId, string.Empty); });
        }

        [Test]
        public void NewGetGoalsForUserRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetGoalsForUserRequest(validGoalId, ValidUsername);

            Assert.IsNotNull(test);

            Assert.AreEqual(validGoalId, test.UserId);

            Assert.AreNotEqual(Guid.Empty, test.RequestReference);

            Assert.IsInstanceOf<GetGoalsForUserRequest>(test);
        }

        [Test]
        public void NewManageGoalsViewModel_ValidParams_ReturnsViewModel()
        {
            var test = assembler.NewManageGoalsViewModel(validGoals);

            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Goals);
            Assert.IsNotNull(test.AddGoal);
            Assert.IsNotNull(test.EditGoal);

            Assert.AreEqual(1, test.Goals.Count);
        }

        [Test]
        public void NewManageGoalsViewModel_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewManageGoalsViewModel(null); });
        }

        [Test]
        public void NewGetGoalsForUserRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetGoalsForUserRequest(Guid.Empty, ValidUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetGoalsForUserRequest(validGoalId, string.Empty); });
        }

        [Test]
        public void NewAddGoalRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewAddGoalRequest(null, ValidUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewAddGoalRequest(validViewModel, string.Empty); });
        }

        [Test]
        public void ProxyToViewModelList_ValidParams_ReturnsViewModel()
        {
            var test = assembler.ProxyToViewModelList(validGoals);

            Assert.IsNotNull(test);
            
            Assert.IsInstanceOf<IList<GoalViewModel>>(test);

            Assert.AreEqual(1, test.Count);
        }
    }
}