namespace MyMoney.Web.Assemblers.Tests.Authentication
{
    #region Usings

    using System;
    using System.Linq;
    using System.Security.Claims;

    using MyMoney.DTO.Request.Authentication;
    using MyMoney.DTO.Response.Authentication;
    using MyMoney.Proxies.Authentication;
    using MyMoney.ViewModels.Authentication.User;
    using MyMoney.Web.Assemblers.Authentication;
    using MyMoney.Web.Assemblers.Authentication.Interfaces;

    using NUnit.Framework;

    #endregion

    [Category("Web Assemblers")]
    [TestFixture]
    public class UserAssemblerTests
    {
        #region Fields

        private IUserAssembler assembler;

        private LoginViewModel validLoginViewModel;

        private RegisterViewModel validRegisterViewModel;

        private ValidateUserResponse validResponse;

        #endregion

        #region Methods

        [Test]
        public void NewClaimsIdentity_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewClaimsIdentity(null); });
        }

        [Test]
        public void NewClaimsIdentity_ValidParams_ReturnsClaimsIdentity()
        {
            var test = assembler.NewClaimsIdentity(validResponse);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ClaimsIdentity>(test);
            Assert.AreEqual(test.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value, "TEST");
            Assert.AreEqual(test.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value, "TEST");
            Assert.AreEqual(test.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value, "TEST");
            Assert.AreEqual(test.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value, "TEST");
        }

        [Test]
        public void NewRegisterUserRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewRegisterUserRequest(null); });
        }

        [Test]
        public void NewRegisterUserRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewRegisterUserRequest(validRegisterViewModel);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<RegisterUserRequest>(test);

            Assert.AreEqual(test.DateOfBirth, DateTime.MinValue);
            Assert.AreEqual(test.EmailAddress, "TEST");
            Assert.AreEqual(test.FirstName, "TEST");
            Assert.AreEqual(test.LastName, "TEST");
            Assert.AreEqual(test.Password, "TEST");
            Assert.AreNotEqual(test.RequestReference, Guid.Empty);
        }

        [Test]
        public void NewValidateUserRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewValidateUserRequest(null); });
        }

        [Test]
        public void NewValidateUserRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewValidateUserRequest(validLoginViewModel);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ValidateUserRequest>(test);
            Assert.AreEqual(test.EmailAddress, "TEST");
            Assert.AreEqual(test.Password, "TEST");
            Assert.AreNotEqual(test.RequestReference, Guid.Empty);
        }

        [SetUp]
        public void SetUp()
        {
            assembler = new UserAssembler();
            validResponse = new ValidateUserResponse
                                {
                                    LoginSuccess = true,
                                    RequestReference = Guid.NewGuid(),
                                    User =
                                        new UserProxy
                                            {
                                                DateOfBirth = DateTime.MinValue,
                                                EmailAddress = "TEST",
                                                FirstName = "TEST",
                                                Id = Guid.NewGuid(),
                                                LastName = "TEST"
                                            }
                                };
            validRegisterViewModel = new RegisterViewModel
                                         {
                                             AcceptTermsAndConditions = true,
                                             ConfirmPassword = "TEST",
                                             DateOfBirth = DateTime.MinValue,
                                             EmailAddress = "TEST",
                                             FirstName = "TEST",
                                             LastName = "TEST",
                                             Password = "TEST"
                                         };
            validLoginViewModel = new LoginViewModel { EmailAddress = "TEST", Password = "TEST", ReturnUrl = "TEST" };
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
            validResponse = null;
            validRegisterViewModel = null;
            validLoginViewModel = null;
        }

        #endregion
    }
}