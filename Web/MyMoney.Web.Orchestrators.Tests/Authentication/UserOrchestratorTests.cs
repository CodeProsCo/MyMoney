namespace MyMoney.Web.Orchestrators.Tests.Authentication
{
    #region Usings

    using System;
    using System.Security.Claims;

    using MyMoney.DTO.Request.Authentication;
    using MyMoney.DTO.Response.Authentication;
    using MyMoney.Proxies.Authentication;
    using MyMoney.ViewModels.Authentication.User;
    using MyMoney.Web.Assemblers.Authentication.Interfaces;
    using MyMoney.Web.DataAccess.Authentication.Interfaces;
    using MyMoney.Web.Orchestrators.Authentication;
    using MyMoney.Web.Orchestrators.Authentication.Interfaces;
    using MyMoney.Wrappers;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    [Category("Web Orchestrators")]
    public class UserOrchestratorTests
    {
        #region Fields

        private IUserAssembler assembler;

        private IUserDataAccess dataAccess;

        private LoginViewModel invalidLoginViewModel;

        private RegisterUserRequest invalidRegisterUserRequest;

        private RegisterUserResponse invalidRegisterUserResponse;

        private RegisterViewModel invalidRegisterViewModel;

        private ValidateUserRequest invalidValidateUserRequest;

        private ValidateUserResponse invalidValidateUserResponse;

        private IUserOrchestrator orchestrator;

        private LoginViewModel validLoginViewModel;

        private RegisterUserRequest validRegisterUserRequest;

        private RegisterUserResponse validRegisterUserResponse;

        private RegisterViewModel validRegisterViewModel;

        private ValidateUserRequest validValidateUserRequest;

        private ValidateUserResponse validValidateUserResponse;

        #endregion

        #region Methods

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new UserOrchestrator(null, dataAccess); });

            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new UserOrchestrator(assembler, null); });
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
                                                  Errors = {
                                                              new ResponseErrorWrapper() 
                                                           },
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
                                                 Username = string.Empty
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
            validRegisterViewModel = null;
            validRegisterUserRequest = null;
            invalidRegisterUserRequest = null;
            validRegisterUserResponse = null;
            invalidRegisterUserResponse = null;
            invalidRegisterViewModel = null;
            invalidLoginViewModel = null;
            validLoginViewModel = null;
            validValidateUserRequest = null;
            invalidValidateUserRequest = null;
            validValidateUserResponse = null;
            invalidValidateUserResponse = null;
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

        #endregion
    }
}