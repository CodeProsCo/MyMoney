namespace MyMoney.API.Assemblers.Tests.Authentication
{
    #region Usings

    using System;

    using Assemblers.Authentication;
    using Assemblers.Authentication.Interfaces;

    using DataModels.Authentication;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using Helpers.Security;
    using Helpers.Security.Interfaces;

    using NSubstitute;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    [Category("API Assemblers")]
    public class UserAssemblerTests
    {
        private IUserAssembler assembler;

        private UserDataModel validDataModel;

        private RegisterUserRequest validRegisterUserRequest;

        private IEncryptionHelper encryptionHelper;

        [SetUp]
        public void SetUp()
        {
            encryptionHelper = Substitute.For<IEncryptionHelper>();

            encryptionHelper.EncryptPassword(Arg.Any<string>())
                .Returns(new EncryptedPasswordModel { Hash = new byte[] { }, Iterations = 1, Salt = new byte[] { } });

            assembler = new UserAssembler(encryptionHelper);

            validDataModel = new UserDataModel
            {
                CreationTime = DateTime.Now,
                DateOfBirth = DateTime.MinValue,
                EmailAddress = "TEST",
                FirstName = "TEST",
                LastName = "TEST",
                Salt = new byte[] { },
                Hash = new byte[] { },
                Iterations = 1,
                Id = Guid.NewGuid()
            };

            validRegisterUserRequest =
                new RegisterUserRequest
                {
                    DateOfBirth = DateTime.MinValue,
                    EmailAddress = "TEST",
                    FirstName = "TEST",
                    LastName = "TEST",
                    Password = "TESTTESTTESTTESTTEST",
                    Username = "TEST"
                };
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
            validDataModel = null;
        }

        [Test]
        public void NewRegisterUserResponse_ValidParams_ReturnsResponse()
        {
            var guid = Guid.NewGuid();

            var test = assembler.NewRegisterUserResponse(validDataModel, guid);

            Assert.IsNotNull(test);

            Assert.IsInstanceOf<RegisterUserResponse>(test);

            Assert.IsTrue(test.Success);

            Assert.AreEqual(test.RequestReference, guid);
        }

        [Test]
        public void NewValidateUserResponse_ValidParams_ReturnsResponse()
        {
            var guid = Guid.NewGuid();

            var test = assembler.NewValidateUserResponse(validDataModel, guid);

            Assert.IsNotNull(test);
            Assert.IsNotNull(test.User);

            Assert.IsInstanceOf<ValidateUserResponse>(test);

            Assert.IsTrue(test.LoginSuccess);

            Assert.AreSame(validDataModel.EmailAddress, test.User.EmailAddress);
            Assert.AreSame(validDataModel.FirstName, test.User.FirstName);
            Assert.AreSame(validDataModel.LastName, test.User.LastName);

            Assert.AreEqual(validDataModel.DateOfBirth, test.User.DateOfBirth);
            Assert.AreEqual(test.RequestReference, guid);
        }

        [Test]
        public void NewUserDataModel_ValidParams_ReturnsDataModel()
        {
            var test = assembler.NewUserDataModel(validRegisterUserRequest);

            Assert.IsNotNull(test);

            Assert.IsInstanceOf<UserDataModel>(test);

            Assert.AreSame(test.EmailAddress, validRegisterUserRequest.EmailAddress);
            Assert.AreSame(test.FirstName, validRegisterUserRequest.FirstName);
            Assert.AreSame(test.LastName, validRegisterUserRequest.LastName);
        }
    }
}