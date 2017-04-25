namespace MyMoney.API.Orchestrators.Tests.Authentication
{
    #region Usings

    using System;

    using Assemblers.Authentication.Interfaces;

    using DataAccess.Authentication.Interfaces;

    using DataModels.Authentication;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using JetBrains.Annotations;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Authentication;
    using Orchestrators.Authentication.Interfaces;

    using Wrappers;

    #endregion

    [TestFixture]
    [Category("API Orchestrators")]
    [UsedImplicitly]
    public class UserOrchestratorTests
    {
        #region Fields

        private IUserAssembler assembler;

        private IUserOrchestrator orchestrator;

        private IUserRepository repository;

        private RegisterUserRequest validRegisterUserRequest;

        private RegisterUserRequest invalidRegisterUserRequest;

        private RegisterUserRequest exceptionRegisterUserRequest;

        private UserDataModel validDataModel;

        private UserDataModel invalidDataModel;

        private RegisterUserResponse validRegisterUserResponse;

        private RegisterUserResponse invalidRegisterUserResponse;

        #endregion

        #region Methods

        [SetUp]
        public void SetUp()
        {
            validRegisterUserRequest =
                new RegisterUserRequest
                {
                    DateOfBirth = DateTime.Today,
                    EmailAddress = "TEST",
                    FirstName = "TEST",
                    LastName = "TEST",
                    Password = "TEST",
                    Username = "TEST"
                };

            validDataModel = new UserDataModel
            {
                Id = Guid.NewGuid(),
                CreationTime = DateTime.Now,
                DateOfBirth = DateTime.Today,
                EmailAddress = "TEST",
                FirstName = "TEST",
                Hash = new byte[] { },
                Iterations = 1,
                LastName = "TEST",
                Salt = new byte[] { }
            };

            validRegisterUserResponse =
                new RegisterUserResponse
                {
                    RegisterSuccess = true,
                    RequestReference = validRegisterUserRequest.RequestReference
                };

            invalidDataModel = new UserDataModel();

            invalidRegisterUserRequest = new RegisterUserRequest();

            invalidRegisterUserResponse = new RegisterUserResponse { Errors = { new ResponseErrorWrapper() } };

            exceptionRegisterUserRequest = new RegisterUserRequest { DateOfBirth = DateTime.MinValue };

            assembler = Substitute.For<IUserAssembler>();
            repository = Substitute.For<IUserRepository>();

            assembler.NewUserDataModel(validRegisterUserRequest).Returns(validDataModel);
            assembler.NewUserDataModel(invalidRegisterUserRequest).Returns(invalidDataModel);
            assembler.NewRegisterUserResponse(validDataModel, validRegisterUserRequest.RequestReference)
                .Returns(validRegisterUserResponse);
            assembler.NewUserDataModel(exceptionRegisterUserRequest).Throws(new Exception("TEST"));
            assembler.NewRegisterUserResponse(invalidDataModel, invalidRegisterUserRequest.RequestReference)
                .Returns(invalidRegisterUserResponse);

            repository.RegisterUser(validDataModel).Returns(validDataModel);
            repository.RegisterUser(invalidDataModel).Returns(invalidDataModel);

            orchestrator = new UserOrchestrator(assembler, repository);
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
            repository = null;
        }

        [Test]
        public void RegisterUser_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.RegisterUser(validRegisterUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<RegisterUserResponse>(test);
            Assert.True(test.RegisterSuccess);
        }

        [Test]
        public void RegisterUser_InvalidParams_ReturnsResponse()
        {
            var test = orchestrator.RegisterUser(invalidRegisterUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<RegisterUserResponse>(test);
            Assert.False(test.RegisterSuccess);
            Assert.AreEqual(test.Errors.Count, 1);
        }

        [Test]
        public void RegisterUser_ExceptionThrown_ReturnsResponse()
        {
            var test = orchestrator.RegisterUser(exceptionRegisterUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<RegisterUserResponse>(test);
            Assert.False(test.RegisterSuccess);
            Assert.AreEqual(test.Errors.Count, 1);
        }

        #endregion
    }
}