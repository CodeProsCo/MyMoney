namespace MyMoney.API.Assemblers.Tests.Saving
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Saving;
    using Assemblers.Saving.Interfaces;

    using DataModels.Saving;

    using DTO.Response.Saving.Goal;

    using NUnit.Framework;

    using Proxies.Saving;

    #endregion

    [TestFixture]
    [Category("API Assemblers")]
    public class GoalAssemblerTests
    {
        private IGoalAssembler assembler;

        private GoalDataModel validDataModel;

        private Guid validGuid;

        private IList<GoalDataModel> validGoals;

        private GoalProxy validGoalProxy;

        [SetUp]
        public void SetUp()
        {
            assembler = new GoalAssembler();
            validDataModel = new GoalDataModel
            {
                CreationTime = DateTime.Now,
                Id = Guid.NewGuid(),
                Amount = 1,
                Complete = true,
                EndDate = DateTime.Now,
                Name = "TEST",
                StartDate = DateTime.Now,
                UserId = Guid.NewGuid()
            };

            validGoals = new List<GoalDataModel> { validDataModel };
            validGoalProxy = new GoalProxy
            {
                Amount = 1.0,
                Complete = true,
                EndDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = "TEST",
                StartDate = DateTime.Now,
                UserId = Guid.NewGuid()
            };

            validGuid = Guid.NewGuid();
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
            validDataModel = null;
            validGoals = null;
        }

        [Test]
        public void NewAddGoalResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewAddGoalResponse(validDataModel, validGuid);

            Assert.IsNotNull(test);

            Assert.IsInstanceOf<AddGoalResponse>(test);

            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.AreEqual(validDataModel.Id, test.Goal.Id);
            Assert.AreEqual(validDataModel.Amount, test.Goal.Amount);
            Assert.AreEqual(validDataModel.EndDate, test.Goal.EndDate);
            Assert.AreEqual(validDataModel.Complete, test.Goal.Complete);
            Assert.AreEqual(validDataModel.StartDate, test.Goal.StartDate);
            Assert.AreEqual(validDataModel.UserId, test.Goal.UserId);
            Assert.AreEqual(validGuid, test.RequestReference);

            Assert.AreSame(validDataModel.Name, test.Goal.Name);
        }

        [Test]
        public void NewAddGoalResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewAddGoalResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewAddGoalResponse(validDataModel, Guid.Empty); });
        }

        [Test]
        public void NewDeleteGoalResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewDeleteGoalResponse(true, validGuid);

            Assert.IsInstanceOf<DeleteGoalResponse>(test);

            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.AreEqual(true, test.DeleteSuccess);
        }

        [Test]
        public void NewDeleteGoalResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewDeleteGoalResponse(true, Guid.Empty); });
        }

        [Test]
        public void NewEditGoalResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewEditGoalResponse(validDataModel, validGuid);

            Assert.IsInstanceOf<EditGoalResponse>(test);

            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.AreEqual(validDataModel.Id, test.Goal.Id);
            Assert.AreEqual(validDataModel.Amount, test.Goal.Amount);
            Assert.AreEqual(validDataModel.EndDate, test.Goal.EndDate);
            Assert.AreEqual(validDataModel.Complete, test.Goal.Complete);
            Assert.AreEqual(validDataModel.StartDate, test.Goal.StartDate);
            Assert.AreEqual(validDataModel.UserId, test.Goal.UserId);
            Assert.AreEqual(validGuid, test.RequestReference);

            Assert.AreSame(validDataModel.Name, test.Goal.Name);
        }

        [Test]
        public void NewEditGoalResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewEditGoalResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewEditGoalResponse(validDataModel, Guid.Empty); });
        }

        [Test]
        public void NewGetGoalResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewGetGoalResponse(validDataModel, validGuid);

            Assert.IsInstanceOf<GetGoalResponse>(test);

            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.AreEqual(validDataModel.Id, test.Goal.Id);
            Assert.AreEqual(validDataModel.Amount, test.Goal.Amount);
            Assert.AreEqual(validDataModel.EndDate, test.Goal.EndDate);
            Assert.AreEqual(validDataModel.Complete, test.Goal.Complete);
            Assert.AreEqual(validDataModel.StartDate, test.Goal.StartDate);
            Assert.AreEqual(validDataModel.UserId, test.Goal.UserId);
            Assert.AreEqual(validGuid, test.RequestReference);

            Assert.AreSame(validDataModel.Name, test.Goal.Name);
        }

        [Test]
        public void NewGetGoalResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewGetGoalResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetGoalResponse(validDataModel, Guid.Empty); });
        }

        [Test]
        public void NewGetGoalsForUserResponse_ValidParmas_ReturnsResponse()
        {
            var test = assembler.NewGetGoalsForUserResponse(validGoals, validGuid);

            Assert.IsInstanceOf<GetGoalsForUserResponse>(test);

            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.AreEqual(1, test.Goals.Count);
            Assert.AreEqual(validGuid, test.RequestReference);
        }

        [Test]
        public void NewGetGoalsForUserResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewGetGoalsForUserResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetGoalsForUserResponse(validGoals, Guid.Empty); });
        }

        [Test]
        public void NewGoalDataModel_ValidParams_ReturnsDataModel()
        {
            var test = assembler.NewGoalDataModel(validGoalProxy);

            Assert.IsNotNull(test);

            Assert.IsInstanceOf<GoalDataModel>(test);

            Assert.AreEqual(validGoalProxy.Id, test.Id);
            Assert.AreEqual(validGoalProxy.Amount, test.Amount);
            Assert.AreEqual(validGoalProxy.EndDate, test.EndDate);
            Assert.AreEqual(validGoalProxy.Complete, test.Complete);
            Assert.AreEqual(validGoalProxy.StartDate, test.StartDate);
            Assert.AreEqual(validGoalProxy.UserId, test.UserId);
        }
    }
}