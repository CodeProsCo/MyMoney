namespace MyMoney.Web.Orchestrators.Tests.Authentication
{
    #region Usings

    using System.Security.Claims;

    using Assemblers.Authentication.Interfaces;

    using DataAccess.Authentication.Interfaces;

    using DTO.Request.Authentication;
    using DTO.Response.Authentication;

    using NSubstitute;

    using NUnit.Framework;

    using Orchestrators.Authentication;
    using Orchestrators.Authentication.Interfaces;

    using ViewModels.Authentication.User;

    using Wrappers;

    #endregion

    /// <summary>
    ///     Tests for the <see cref="UserOrchestrator" /> class.
    /// </summary>
    [TestFixture]
    public class UserOrchestratorTests
    {
        /// <summary>
        ///     Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            dataAccess = Substitute.For<IUserDataAccess>();
            assembler = Substitute.For<IUserAssembler>();

            dataAccess.GetClaimForUser(Arg.Any<GetClaimForUserRequest>())
                .ReturnsForAnyArgs(new GetClaimForUserResponse());
            assembler.NewClaimsIdentity(Arg.Any<GetClaimForUserResponse>()).ReturnsForAnyArgs(new ClaimsIdentity());
            assembler.NewGetClaimForUserRequest(Arg.Any<LoginViewModel>())
                .ReturnsForAnyArgs(new GetClaimForUserRequest());

            orchestrator = new UserOrchestrator(assembler, dataAccess);
        }

        /// <summary>
        ///     Tears down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            dataAccess = null;
            assembler = null;
            orchestrator = null;
        }

        /// <summary>
        ///     The orchestrator
        /// </summary>
        private IUserOrchestrator orchestrator;

        /// <summary>
        ///     The data access
        /// </summary>
        private IUserDataAccess dataAccess;

        /// <summary>
        ///     The assembler
        /// </summary>
        private IUserAssembler assembler;

        /// <summary>
        ///     Asserts that when using valid parameters, the user orchestrator returns a valid instance of the
        ///     <see cref="ClaimsIdentity" /> class.
        /// </summary>
        [Test]
        public void GetClaimForUser_ValidParams_ReturnsWrappedClaimsIdentity()
        {
            var test = orchestrator.GetClaimForUser(new LoginViewModel()).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<ClaimsIdentity>>(test);
            Assert.IsInstanceOf<ClaimsIdentity>(test.Model);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
        }
    }
}