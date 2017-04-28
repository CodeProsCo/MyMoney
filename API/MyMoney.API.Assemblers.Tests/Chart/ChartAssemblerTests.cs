namespace MyMoney.API.Assemblers.Tests.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Chart;
    using Assemblers.Chart.Interfaces;

    using DTO.Response.Chart.Bill;
    using DTO.Response.Chart.Expenditure;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    [Category("API Assemblers")]
    public class ChartAssemblerTests
    {
        private IChartAssembler assembler;

        [SetUp]
        public void SetUp()
        {
            assembler = new ChartAssembler();
            validData = new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("TEST", 1) };
            validGuid = Guid.NewGuid();
            validExpData =
                new List<KeyValuePair<DateTime, double>> { new KeyValuePair<DateTime, double>(DateTime.Today, 1.0) };
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
            validData = null;
            validExpData = null;
        }

        private IList<KeyValuePair<string, int>> validData;

        private Guid validGuid;

        private IList<KeyValuePair<DateTime, double>> validExpData;

        [Test]
        public void NewGetBillCategoryChartDataResponse_ValidParmas_ReturnsResponse()
        {
            var test = assembler.NewGetBillCategoryChartDataResponse(validData, validGuid);

            Assert.IsNotNull(test);

            Assert.IsInstanceOf<GetBillCategoryChartDataResponse>(test);
            Assert.AreEqual(1, test.Data.Count);
            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.AreEqual(validGuid, test.RequestReference);

            Assert.IsTrue(test.Success);
        }

        [Test]
        public void NewGetBillPeriodChartDataResponse_ValidParmas_ReturnsResponse()
        {
            var test = assembler.NewGetBillPeriodChartDataResponse(validData, validGuid);

            Assert.IsNotNull(test);

            Assert.IsInstanceOf<GetBillPeriodChartDataResponse>(test);

            Assert.AreEqual(1, test.Data.Count);
            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.AreEqual(validGuid, test.RequestReference);

            Assert.IsTrue(test.Success);
        }

        [Test]
        public void NewGetExpenditureChartDataResponse_ValidParmas_ReturnsResponse()
        {
            var test = assembler.NewGetExpenditureChartDataResponse(validExpData, validGuid);

            Assert.IsNotNull(test);

            Assert.IsInstanceOf<GetExpenditureChartDataResponse>(test);

            Assert.AreEqual(1, test.Data.Count);
            Assert.AreEqual(0, test.Errors.Count);
            Assert.AreEqual(0, test.Warnings.Count);
            Assert.AreEqual(validGuid, test.RequestReference);

            Assert.IsTrue(test.Success);
        }
    }
}