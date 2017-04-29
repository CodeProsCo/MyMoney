namespace MyMoney.API.Assemblers.Tests.Spending
{
    #region Usings

    using Assemblers.Spending;
    using Assemblers.Spending.Interfaces;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    [Category("API Assemblers")]
    public class ExpenditureAssemblerTests
    {
        private IExpenditureAssembler assembler;

        [SetUp]
        public void SetUp()
        {
            assembler = new ExpenditureAssembler();
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
        }
    }
}