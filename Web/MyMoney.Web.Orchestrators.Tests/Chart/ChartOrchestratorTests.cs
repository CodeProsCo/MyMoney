namespace MyMoney.Web.Orchestrators.Tests.Chart
{
    #region Usings

    using System;

    using Assemblers.Chart.Interfaces;

    using DataAccess.Chart.Interfaces;

    using NSubstitute;

    using NUnit.Framework;

    using Orchestrators.Chart;
    using Orchestrators.Chart.Interfaces;

    #endregion

    [TestFixture]
    [Category("Web Orchestrators")]
    public class ChartOrchestratorTests
    {
        [SetUp]
        public void SetUp()
        {
            assembler = Substitute.For<IChartAssembler>();
            dataAccess = Substitute.For<IChartDataAccess>();

            orchestrator = new ChartOrchestrator(assembler, dataAccess);
        }

        [TearDown]
        public void TearDown()
        {
            orchestrator = null;
            assembler = null;
            dataAccess = null;
        }

        private IChartOrchestrator orchestrator;

        private IChartAssembler assembler;

        private IChartDataAccess dataAccess;

        [Test]
        public void Constructor_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new ChartOrchestrator(null, dataAccess); });

            Assert.Throws<ArgumentNullException>(delegate { orchestrator = new ChartOrchestrator(assembler, null); });
        }
    }
}