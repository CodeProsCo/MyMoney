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

        private ValidateUserRequest validValidateUserRequest;

        private ValidateUserRequest invalidValidateUserRequest;

        private ValidateUserRequest exceptionValidateUserRequest;

        private UserDataModel validDataModel;

        private UserDataModel invalidDataModel;

        private RegisterUserResponse validRegisterUserResponse;

        private RegisterUserResponse invalidRegisterUserResponse;

        private ValidateUserResponse validValidateUserResponse;

        private ValidateUserResponse invalidValidateUserResponse;

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

            validValidateUserRequest =
                new ValidateUserRequest { EmailAddress = "TEST", Password = "TEST", Username = "TEST" };
            invalidValidateUserRequest = new ValidateUserRequest();
            exceptionValidateUserRequest = new ValidateUserRequest { EmailAddress = "EXC", Password = "EXC", Username = "EXC"};

            invalidValidateUserResponse = new ValidateUserResponse { Errors = { new ResponseErrorWrapper() } };
            validValidateUserResponse = new ValidateUserResponse { LoginSuccess = true };

            assembler = Substitute.For<IUserAssembler>();
            repository = Substitute.For<IUserRepository>();

            assembler.NewUserDataModel(validRegisterUserRequest).Returns(validDataModel);
            assembler.NewUserDataModel(invalidRegisterUserRequest).Returns(invalidDataModel);
            assembler.NewRegisterUserResponse(validDataModel, validRegisterUserRequest.RequestReference)
                .Returns(validRegisterUserResponse);
            assembler.NewUserDataModel(exceptionRegisterUserRequest).Throws(new Exception("TEST"));
            assembler.NewRegisterUserResponse(invalidDataModel, invalidRegisterUserRequest.RequestReference)
                .Returns(invalidRegisterUserResponse);
            assembler.NewValidateUserResponse(validDataModel, validValidateUserRequest.RequestReference)
                .Returns(validValidateUserResponse);
            assembler.NewValidateUserResponse(invalidDataModel, invalidValidateUserRequest.RequestReference)
                .Returns(invalidValidateUserResponse);
           

            repository.RegisterUser(validDataModel).Returns(validDataModel);
            repository.RegisterUser(invalidDataModel).Returns(invalidDataModel);
            repository.GetUser(validValidateUserRequest.EmailAddress, validValidateUserRequest.Password)
                .Returns(validDataModel);
            repository.GetUser(invalidValidateUserRequest.EmailAddress, invalidRegisterUserRequest.Password)
                .Returns(invalidDataModel);
            repository.GetUser(exceptionValidateUserRequest.EmailAddress, exceptionValidateUserRequest.Password)
                .Throws(new Exception("TEST"));

            

            orchestrator = new UserOrchestrator(assembler, repository);
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
            repository = null;
        }

        [Test]
        public void ValidateUser_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.ValidateUser(validValidateUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ValidateUserResponse>(test);
            Assert.True(test.LoginSuccess);
        }

        [Test]
        public void ValidateUser_InvalidParams_ReturnsResponse()
        {
            var test = orchestrator.ValidateUser(invalidValidateUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ValidateUserResponse>(test);
            Assert.False(test.LoginSuccess);
            Assert.AreEqual(test.Errors.Count, 1);
        }

        [Test]
        public void ValidateUser_ExceptionThrown_ReturnsResponse()
        {
            var test = orchestrator.ValidateUser(exceptionValidateUserRequest).Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ValidateUserResponse>(test);
            Assert.False(test.LoginSuccess);
            Assert.AreEqual(test.Errors.Count, 1);
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

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new UserOrchestrator(null, repository); });
            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new UserOrchestrator(assembler, null); });
        }



        #endregion
    }
}