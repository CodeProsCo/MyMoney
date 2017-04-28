namespace MyMoney.Web.Orchestrators.Tests.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Chart.Interfaces;

    using DataAccess.Chart.Interfaces;

    using DTO.Request.Chart.Bill;
    using DTO.Response.Chart.Bill;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Chart;
    using Orchestrators.Chart.Interfaces;

    using ViewModels.Enum;

    using Wrappers;

    #endregion

    [TestFixture]
    [Category("Web Orchestrators")]
    public class ChartOrchestratorTests
    {
        #region Fields

        private IChartAssembler assembler;

        private IChartDataAccess dataAccess;

        private GetBillCategoryChartDataRequest invalidGetBillCategoryChartDataRequest;

        private GetBillCategoryChartDataResponse invalidGetBillCategoryChartDataResponse;

        private GetBillPeriodChartDataRequest invalidGetBillPeriodChartDataRequest;

        private GetBillPeriodChartDataResponse invalidGetBillPeriodChartDataResponse;

        private Guid invalidUserId;

        private IChartOrchestrator orchestrator;

        private GetBillCategoryChartDataRequest validGetBillCategoryChartDataRequest;

        private GetBillCategoryChartDataResponse validGetBillCategoryChartDataResponse;

        private GetBillPeriodChartDataRequest validGetBillPeriodChartDataRequest;

        private GetBillPeriodChartDataResponse validGetBillPeriodChartDataResponse;

        private Guid validUserId;

        private string validUsername;

        #endregion

        #region Methods

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new ChartOrchestrator(null, dataAccess); });

            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new ChartOrchestrator(assembler, null); });
        }

        [Test]
        public void GetBillCategoryChartData_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillCategoryChartData(invalidUserId, string.Empty).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<KeyValuePair<string, int>>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(test.Errors.Count, 1);
            Assert.IsFalse(test.Success);
        }

        [Test]
        public void GetBillCategoryChartData_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillCategoryChartData(invalidUserId, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<KeyValuePair<string, int>>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(test.Errors.Count, 1);
            Assert.IsFalse(test.Success);
        }

        [Test]
        public void GetBillCategoryChartData_ValidParams_ReturnsKeyValuePairs()
        {
            var test = orchestrator.GetBillCategoryChartData(validUserId, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<KeyValuePair<string, int>>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(test.Errors.Count, 0);
            Assert.IsTrue(test.Success);
        }

        [Test]
        public void GetBillPeriodChartData_ExceptionThrown_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillPeriodChartData(invalidUserId, string.Empty).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<KeyValuePair<TimePeriod, int>>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(test.Errors.Count, 1);
            Assert.IsFalse(test.Success);
        }

        [Test]
        public void GetBillPeriodChartData_InvalidParams_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillPeriodChartData(invalidUserId, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<KeyValuePair<TimePeriod, int>>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNull(test.Model);
            Assert.AreEqual(test.Errors.Count, 1);
            Assert.IsFalse(test.Success);
        }

        [Test]
        public void GetExpenditureChartData_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetExpenditureChartData(validUserId, validUsername);
        }

        [Test]
        public void GetBillPeriodChartData_ValidParams_ReturnsKeyValuePairs()
        {
            var test = orchestrator.GetBillPeriodChartData(validUserId, validUsername).Result;

            Assert.IsInstanceOf<OrchestratorResponseWrapper<IList<KeyValuePair<TimePeriod, int>>>>(test);
            Assert.IsNotNull(test);
            Assert.IsNotNull(test.Model);
            Assert.AreEqual(test.Errors.Count, 0);
            Assert.IsTrue(test.Success);
        }

        [SetUp]
        public void SetUp()
        {
            assembler = Substitute.For<IChartAssembler>();
            dataAccess = Substitute.For<IChartDataAccess>();
            validUserId = Guid.NewGuid();
            invalidUserId = Guid.Empty;
            validUsername = "TEST";

            validGetBillCategoryChartDataRequest = new GetBillCategoryChartDataRequest
                                                       {
                                                           UserId = validUserId,
                                                           Username = validUsername
                                                       };

            invalidGetBillCategoryChartDataRequest = new GetBillCategoryChartDataRequest();

            validGetBillCategoryChartDataResponse = new GetBillCategoryChartDataResponse
                                                        {
                                                            Data =
                                                                new List
                                                                <
                                                                    KeyValuePair<string, int>>()
                                                        };

            invalidGetBillPeriodChartDataResponse = new GetBillPeriodChartDataResponse
                                                        {
                                                            Errors =
                                                                {
                                                                    new ResponseErrorWrapper
                                                                        ()
                                                                }
                                                        };

            validGetBillPeriodChartDataRequest = new GetBillPeriodChartDataRequest
                                                     {
                                                         UserId = validUserId,
                                                         Username = validUsername
                                                     };

            invalidGetBillPeriodChartDataRequest = new GetBillPeriodChartDataRequest();

            validGetBillPeriodChartDataResponse = new GetBillPeriodChartDataResponse
                                                      {
                                                          Data =
                                                              new List
                                                              <
                                                                  KeyValuePair<string, int>>()
                                                      };

            invalidGetBillPeriodChartDataResponse = new GetBillPeriodChartDataResponse
                                                        {
                                                            Errors =
                                                                {
                                                                    new ResponseErrorWrapper
                                                                        ()
                                                                }
                                                        };
            invalidGetBillCategoryChartDataResponse = new GetBillCategoryChartDataResponse
                                                          {
                                                              Errors =
                                                                  {
                                                                      new ResponseErrorWrapper
                                                                          ()
                                                                  }
                                                          };

            assembler.NewGetBillCategoryChartDataRequest(invalidUserId, validUsername)
                .Returns(invalidGetBillCategoryChartDataRequest);
            assembler.NewGetBillCategoryChartDataRequest(validUserId, validUsername)
                .Returns(validGetBillCategoryChartDataRequest);
            assembler.NewGetBillCategoryChartDataRequest(validUserId, string.Empty)
                .Throws(new Exception("TEST EXCEPTION"));

            dataAccess.GetBillCategoryChartData(validGetBillCategoryChartDataRequest)
                .Returns(validGetBillCategoryChartDataResponse);
            dataAccess.GetBillCategoryChartData(invalidGetBillCategoryChartDataRequest)
                .Returns(invalidGetBillCategoryChartDataResponse);

            assembler.NewGetBillPeriodChartDataRequest(invalidUserId, validUsername)
                .Returns(invalidGetBillPeriodChartDataRequest);
            assembler.NewGetBillPeriodChartDataRequest(validUserId, validUsername)
                .Returns(validGetBillPeriodChartDataRequest);
            assembler.NewGetBillPeriodChartDataRequest(validUserId, string.Empty)
                .Throws(new Exception("TEST EXCEPTION"));

            dataAccess.GetBillPeriodChartData(validGetBillPeriodChartDataRequest)
                .Returns(validGetBillPeriodChartDataResponse);
            dataAccess.GetBillPeriodChartData(invalidGetBillPeriodChartDataRequest)
                .Returns(invalidGetBillPeriodChartDataResponse);

            orchestrator = new ChartOrchestrator(assembler, dataAccess);
        }

        [TearDown]
        public void TearDown()
        {
            orchestrator = null;
            assembler = null;
            dataAccess = null;
        }

        #endregion
    }
}