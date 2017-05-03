namespace MyMoney.API.Orchestrators.Tests.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Chart.Interfaces;

    using DataAccess.Spending.Interfaces;

    using DataModels.Spending;

    using DataTransformers.Spending.Interfaces;

    using DTO.Request.Chart.Bill;
    using DTO.Request.Chart.Expenditure;
    using DTO.Response.Chart.Bill;
    using DTO.Response.Chart.Expenditure;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    using Orchestrators.Chart;
    using Orchestrators.Chart.Interfaces;

    #endregion

    [TestFixture]
    [Category("API Orchestrators")]
    public class ChartOrchestratorTests
    {
        private IChartOrchestrator orchestrator;

        private IChartAssembler assembler;

        private IBillRepository billRepository;

        private IBillDataTransformer billDataTransformer;

        private IExpenditureRepository expenditureRepository;

        private IExpenditureDataTransformer expenditureDataTransformer;

        private GetBillCategoryChartDataRequest validGetBillCategoryChartDataRequest;

        private GetBillCategoryChartDataResponse validGetBillCategoryChartDataResponse;

        private GetBillCategoryChartDataRequest invalidGetBillCategoryChartDataRequest;

        private GetBillPeriodChartDataRequest validGetBillPeriodChartDataRequest;

        private GetBillPeriodChartDataResponse validGetBillPeriodChartDataResponse;

        private GetBillPeriodChartDataRequest invalidGetBillPeriodChartDataRequest;

        private GetExpenditureChartDataResponse validGetExpenditureChartDataResponse;

        private GetExpenditureChartDataRequest validGetExpenditureChartDataRequest;

        private GetExpenditureChartDataRequest invalidGetExpenditureChartDataRequest;

        private IList<BillDataModel> validBills;

        private IList<KeyValuePair<string, int>> validData;

        private IList<ExpenditureDataModel> validExpenditure;

        [SetUp]
        public void SetUp()
        {
            assembler = Substitute.For<IChartAssembler>();
            billRepository = Substitute.For<IBillRepository>();
            billDataTransformer = Substitute.For<IBillDataTransformer>();
            expenditureRepository = Substitute.For<IExpenditureRepository>();
            expenditureDataTransformer = Substitute.For<IExpenditureDataTransformer>();

            validGetBillCategoryChartDataRequest = new GetBillCategoryChartDataRequest
            {
                UserId = Guid.NewGuid(),
                Username = "TEST"
            };

            validGetBillPeriodChartDataRequest = new GetBillPeriodChartDataRequest
            {
                UserId = Guid.NewGuid(),
                Username = "TEST"
            };

            validGetExpenditureChartDataRequest =
                new GetExpenditureChartDataRequest { Month = 1, UserId = Guid.NewGuid(), Username = "TEST" };

            validBills = new List<BillDataModel>();
            validExpenditure = new List<ExpenditureDataModel>();

            invalidGetBillPeriodChartDataRequest = new GetBillPeriodChartDataRequest();
            invalidGetBillCategoryChartDataRequest = new GetBillCategoryChartDataRequest();
            invalidGetExpenditureChartDataRequest = new GetExpenditureChartDataRequest();

            billRepository.GetBillsForUser(validGetBillCategoryChartDataRequest.UserId).Returns(validBills);
            billRepository.GetBillsForUser(validGetBillPeriodChartDataRequest.UserId).Returns(validBills);
            billRepository.GetBillsForUser(Guid.Empty).Throws(new Exception("TEST"));

            expenditureRepository.GetExpenditureForUserForMonth(validGetExpenditureChartDataRequest.UserId)
                .Returns(validExpenditure);
            expenditureRepository.GetExpenditureForUserForMonth(Guid.Empty).Throws(new Exception("TEST"));

            validData = new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("TEST", 1) };

            billDataTransformer.GetBillCategoryChartData(validBills).Returns(validData);
            billDataTransformer.GetBillPeriodChartData(validBills).Returns(validData);

            expenditureDataTransformer.GetRollingExpenditureSum(validExpenditure)
                .Returns(
                    new List<KeyValuePair<DateTime, double>>
                        {
                            new KeyValuePair<DateTime, double>(DateTime.Now, 1.0)
                        });

            validGetBillPeriodChartDataResponse = new GetBillPeriodChartDataResponse { Data = validData };
            validGetBillCategoryChartDataResponse = new GetBillCategoryChartDataResponse { Data = validData };
            validGetExpenditureChartDataResponse =
                new GetExpenditureChartDataResponse
                {
                    Data = new List<KeyValuePair<DateTime, double>>
                                   {
                                       new KeyValuePair<DateTime, double>(DateTime.Now, 1.0)
                                   }
                };

            assembler.NewGetExpenditureChartDataResponse(Arg.Any<IList<KeyValuePair<DateTime, double>>>(), Arg.Any<Guid>()).Returns(validGetExpenditureChartDataResponse);
            assembler.NewGetBillCategoryChartDataResponse(validData, Arg.Any<Guid>()).Returns(validGetBillCategoryChartDataResponse);
            assembler.NewGetBillPeriodChartDataResponse(validData, Arg.Any<Guid>()).Returns(validGetBillPeriodChartDataResponse);

            orchestrator = new ChartOrchestrator(
                assembler,
                billRepository,
                billDataTransformer,
                expenditureRepository,
                expenditureDataTransformer);
        }

        [TearDown]
        public void TearDown()
        {
            orchestrator = null;
            assembler = null;
            billRepository = null;
            billDataTransformer = null;
            expenditureRepository = null;
            expenditureDataTransformer = null;
        }

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        orchestrator = new ChartOrchestrator(
                            null,
                            billRepository,
                            billDataTransformer,
                            expenditureRepository,
                            expenditureDataTransformer);
                    });

            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        orchestrator = new ChartOrchestrator(
                            assembler,
                            null,
                            billDataTransformer,
                            expenditureRepository,
                            expenditureDataTransformer);
                    });

            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        orchestrator = new ChartOrchestrator(
                            assembler,
                            billRepository,
                            null,
                            expenditureRepository,
                            expenditureDataTransformer);
                    });

            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        orchestrator = new ChartOrchestrator(
                            assembler,
                            billRepository,
                            billDataTransformer,
                            null,
                            expenditureDataTransformer);
                    });

            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        orchestrator = new ChartOrchestrator(
                            assembler,
                            billRepository,
                            billDataTransformer,
                            expenditureRepository,
                            null);
                    });
        }

        [Test]
        public void GetBillCategoryChartData_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetBillCategoryChartData(validGetBillCategoryChartDataRequest).Result;

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Data.Count);
            Assert.IsInstanceOf<GetBillCategoryChartDataResponse>(test);
        }

        [Test]
        public void GetBillCategoryChartData_ThrowsException_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillCategoryChartData(invalidGetBillCategoryChartDataRequest).Result;

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Errors.Count);
            Assert.IsInstanceOf<GetBillCategoryChartDataResponse>(test);
        }

        [Test]
        public void GetBillPeriodChartData_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetBillPeriodChartData(validGetBillPeriodChartDataRequest).Result;

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Data.Count);
            Assert.IsInstanceOf<GetBillPeriodChartDataResponse>(test);
        }

        [Test]
        public void GetBillPeriodChartData_ThrowsException_ReturnsErrorResponse()
        {
            var test = orchestrator.GetBillPeriodChartData(invalidGetBillPeriodChartDataRequest).Result;

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Errors.Count);
            Assert.IsInstanceOf<GetBillPeriodChartDataResponse>(test);
        }

        [Test]
        public void GetExpenditureChartData_ValidParams_ReturnsResponse()
        {
            var test = orchestrator.GetExpenditureChartData(validGetExpenditureChartDataRequest).Result;

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Data.Count);
            Assert.IsInstanceOf<GetExpenditureChartDataResponse>(test);
        }

        [Test]
        public void GetExpenditureChartData_ThrowsException_ReturnsErrorResponse()
        {
            var test = orchestrator.GetExpenditureChartData(invalidGetExpenditureChartDataRequest).Result;

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Errors.Count);
            Assert.IsInstanceOf<GetExpenditureChartDataResponse>(test);
        }
    }
}