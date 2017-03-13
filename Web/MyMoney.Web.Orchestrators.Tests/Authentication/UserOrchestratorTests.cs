namespace MyMoney.Web.Orchestrators.Tests.Authentication
{
    #region Usings

    using System;
    using System.Security.Claims;

    using Assemblers.Authentication.Interfaces;

    using DataAccess.Authentication.Interfaces;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Authentication;
    using Orchestrators.Authentication.Interfaces;

    using Proxies.Authentication;

    using ViewModels.Authentication.User;

    using Wrappers;

    #endregion

    [TestFixture]
    [Category("Orchestrators")]
    public class UserOrchestratorTests
    {
        private IUserOrchestrator orchestrator;

        private IUserAssembler assembler;

        private IUserDataAccess dataAccess;

        private RegisterViewModel validRegisterViewModel;

        private RegisterUserRequest validRegisterUserRequest;

        private RegisterUserRequest invalidRegisterUserRequest;

        private RegisterUserResponse validRegisterUserResponse;

        private RegisterUserResponse invalidRegisterUserResponse;

        private RegisterViewModel invalidRegisterViewModel;

        private LoginViewModel invalidLoginViewModel;

        private LoginViewModel validLoginViewModel;

        private ValidateUserRequest validValidateUserRequest;

        private ValidateUserRequest invalidValidateUserRequest;

        private ValidateUserResponse validValidateUserResponse;

        private ValidateUserResponse invalidValidateUserResponse;

        [SetUp]
        public void SetUp()
        {
            assembler = Substitute.For<IUserAssembler>();
            dataAccess = Substitute.For<IUserDataAccess>();

            validRegisterUserRequest = new RegisterUserRequest
            {
                DateOfBirth = DateTime.Now,
                EmailAddress = "TEST",
                FirstName = "TEST",
                LastName = "TEST",
                Password = "TEST",
                Username = "TEST"
            };

            validValidateUserResponse = new ValidateUserResponse
            {
                LoginSuccess = true,
                RequestReference = Guid.NewGuid(),
                User =
                                                    new UserProxy
                                                    {
                                                        EmailAddress = "TEST",
                                                        DateOfBirth = DateTime.Now,
                                                        FirstName = "TEST",
                                                        Id = Guid.NewGuid(),
                                                        LastName = "TEST"
                                                    }
            };

            invalidValidateUserResponse = new ValidateUserResponse { Errors = { new ResponseErrorWrapper() } };

            validValidateUserRequest = new ValidateUserRequest
            {
                EmailAddress = "TEST",
                Password = "TEST",
                Username = "TEST"
            };

            invalidValidateUserRequest = new ValidateUserRequest
            {
                EmailAddress = string.Empty,
                Password = string.Empty,
                Username = string.Empty
            };

            validLoginViewModel = new LoginViewModel { EmailAddress = "TEST", Password = "TEST", ReturnUrl = "TEST" };

            invalidLoginViewModel = new LoginViewModel
            {
                EmailAddress = string.Empty,
                Password = string.Empty,
                ReturnUrl = string.Empty
            };

            invalidRegisterViewModel = new RegisterViewModel
            {
                AcceptTermsAndConditions = false,
                ConfirmPassword = string.Empty,
                DateOfBirth = DateTime.MinValue,
                EmailAddress = string.Empty,
                FirstName = string.Empty,
                LastName = string.Empty,
                Password = string.Empty
            };

            validRegisterUserResponse = new RegisterUserResponse
            {
                RequestReference = Guid.NewGuid(),
                RegisterSuccess = true
            };

            invalidRegisterUserResponse = new RegisterUserResponse
            {
                RequestReference = Guid.NewGuid(),
                Errors = { new ResponseErrorWrapper() },
                RegisterSuccess = false
            };

            validRegisterViewModel = new RegisterViewModel
            {
                AcceptTermsAndConditions = true,
                ConfirmPassword = "TEST",
                DateOfBirth = DateTime.Now,
                EmailAddress = "TEST",
                FirstName = "TEST",
                LastName = "TEST",
                Password = "TEST"
            };

            invalidRegisterUserRequest = new RegisterUserRequest
            {
                DateOfBirth = DateTime.MinValue,
                EmailAddress = string.Empty,
                FirstName = string.Empty,
                LastName = string.Empty,
                Password = string.Empty,
                Username = string.Empty,
            };

            assembler.NewRegisterUserRequest(invalidRegisterViewModel).Returns(invalidRegisterUserRequest);
            assembler.NewRegisterUserRequest(validRegisterViewModel).Returns(validRegisterUserRequest);
            assembler.NewRegisterUserRequest(null).Throws(new Exception("TEST EXCEPTION"));

            assembler.NewValidateUserRequest(invalidLoginViewModel).Returns(invalidValidateUserRequest);
            assembler.NewValidateUserRequest(validLoginViewModel).Returns(validValidateUserRequest);
            assembler.NewValidateUserRequest(null).Throws(new Exception("TEST EXCEPTION"));

            assembler.NewClaimsIdentity(validValidateUserResponse).Returns(new ClaimsIdentity());

            dataAccess.RegisterUser(invalidRegisterUserRequest).Returns(invalidRegisterUserResponse);
            dataAccess.RegisterUser(validRegisterUserRequest).Returns(validRegisterUserResponse);

            dataAccess.ValidateUser(invalidValidateUserRequest).Returns(invalidValidateUserResponse);
            dataAccess.ValidateUser(validValidateUserRequest).Returns(validValidateUserResponse);

            orchestrator = new UserOrchestrator(assembler, dataAccess);
        }

        [TearDown]
        public void TearDown()
        {
            orchestrator = null;
            assembler = null;
            dataAccess = null;
        }

        [Test]
        public void ValidateUser_ValidParams_ReturnsModelWrapper()
        {
            var task = orchestrator.ValidateUser(validLoginViewModel);

            task.Wait();

            var test = task.Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<ClaimsIdentity>>(test);
            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.Model);
        }

        [Test]
        public void ValidateUser_InvalidRequest_ReturnsError()
        {
            var task = orchestrator.ValidateUser(invalidLoginViewModel);

            task.Wait();

            var test = task.Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<ClaimsIdentity>>(test);
            Assert.AreEqual(1, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Model);
        }

        [Test]
        public void ValidateUser_NullParams_ReturnsError()
        {
            var task = orchestrator.ValidateUser(null);

            task.Wait();

            var test = task.Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<ClaimsIdentity>>(test);
            Assert.AreEqual(1, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.IsFalse(test.Success);
            Assert.IsNull(test.Model);
        }

        [Test]
        public void RegisterUser_ValidParams_ReturnsModelWrapper()
        {
            var task = orchestrator.RegisterUser(validRegisterViewModel);

            task.Wait();

            var test = task.Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.IsTrue(test.Success);
            Assert.IsTrue(test.Model);
        }

        [Test]
        public void RegisterUser_InvalidRequest_ReturnsError()
        {
            var task = orchestrator.RegisterUser(invalidRegisterViewModel);

            task.Wait();

            var test = task.Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.AreEqual(1, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.IsFalse(test.Success);
            Assert.IsFalse(test.Model);
        }

        [Test]
        public void RegisterUser_NullParams_ReturnsError()
        {
            var task = orchestrator.RegisterUser(null);

            task.Wait();

            var test = task.Result;

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<OrchestratorResponseWrapper<bool>>(test);
            Assert.AreEqual(1, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.IsFalse(test.Success);
            Assert.IsFalse(test.Model);
        }

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        orchestrator = new UserOrchestrator(null, dataAccess);
                    });

            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        orchestrator = new UserOrchestrator(assembler, null);
                    });
        }
    }
}