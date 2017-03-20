﻿namespace MyMoney.Web.Assemblers.Tests.Chart
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Chart;
    using Assemblers.Chart.Interfaces;

    using DTO.Request.Chart.Bill;

    using NUnit.Framework;

    using ViewModels.Spending.Bills.Enum;

    #endregion

    [Category("Web Assemblers")]
    [TestFixture]
    public class ChartAssemblerTests
    {
        [SetUp]
        public void SetUp()
        {
            assembler = new ChartAssembler();
            validTimePeriodData = new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>("1", 1) };
            validUserId = Guid.NewGuid();
            validUsername = "TEST";
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
            validTimePeriodData = null;
        }

        private IChartAssembler assembler;

        private IEnumerable<KeyValuePair<string, int>> validTimePeriodData;

        private Guid validUserId;

        private string validUsername;

        [Test]
        public void AssembleTimePeriodList_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.AssembleTimePeriodList(null); });
        }

        [Test]
        public void AssembleTimePeriodList_ValidParams_ReturnsPeriodList()
        {
            var test = assembler.AssembleTimePeriodList(validTimePeriodData);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<IList<KeyValuePair<TimePeriod, int>>>(test);
            Assert.AreEqual(1, test.Count);
        }

        [Test]
        public void NewGetBillCategoryChartDataRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillCategoryChartDataRequest(Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillCategoryChartDataRequest(validUserId, string.Empty); });
        }

        [Test]
        public void NewGetBillCategoryChartDataRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetBillCategoryChartDataRequest(validUserId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillCategoryChartDataRequest>(test);
            Assert.AreEqual(test.UserId, validUserId);
            Assert.AreEqual(test.Username, validUsername);
        }

        [Test]
        public void NewGetBillPeriodChartDataRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillPeriodChartDataRequest(Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetBillPeriodChartDataRequest(validUserId, string.Empty); });
        }

        [Test]
        public void NewGetBillPeriodChartDataRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetBillPeriodChartDataRequest(validUserId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetBillPeriodChartDataRequest>(test);
            Assert.AreEqual(test.UserId, validUserId);
            Assert.AreEqual(test.Username, validUsername);
        }
    }
}