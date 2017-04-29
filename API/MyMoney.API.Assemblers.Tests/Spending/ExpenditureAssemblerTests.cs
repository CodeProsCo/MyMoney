namespace MyMoney.API.Assemblers.Tests.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Spending;
    using Assemblers.Spending.Interfaces;

    using DataModels.Common;
    using DataModels.Spending;

    using DTO.Response.Spending.Expenditure;

    using NUnit.Framework;

    using Proxies.Common;
    using Proxies.Spending;

    #endregion

    [TestFixture]
    [Category("API Assemblers")]
    public class ExpenditureAssemblerTests
    {
        private IExpenditureAssembler assembler;

        private ExpenditureProxy validProxy;

        private ExpenditureDataModel validDataModel;

        private Guid validGuid;

        [SetUp]
        public void SetUp()
        {
            validGuid = Guid.NewGuid();
            validDataModel = new ExpenditureDataModel
            {
                Amount = 1,
                Category =
                                         new CategoryDataModel
                                         {
                                             CreationTime = DateTime.Now,
                                             Id = validGuid,
                                             Name = "TEST"
                                         },
                CategoryId = validGuid,
                CreationTime = DateTime.Now,
                Id = validGuid,
                UserId = validGuid
            };

            validProxy = new ExpenditureProxy
            {
                Amount = 1,
                Category = new CategoryProxy { Id = validGuid, Name = "TEST" },
                CategoryId = validGuid,
                Id = validGuid,
                UserId = validGuid
            };

            assembler = new ExpenditureAssembler();
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
        }

        [Test]
        public void NewAddExpenditureResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewAddExpenditureResponse(validDataModel, validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddExpenditureResponse>(test);
            Assert.IsNotNull(test.Expenditure);
        }

        [Test]
        public void NewAddExpenditureResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewAddExpenditureResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewAddExpenditureResponse(validDataModel, Guid.Empty); });
        }

        [Test]
        public void NewDeleteExpenditureResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewDeleteExpenditureResponse(true, validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteExpenditureResponse>(test);
            Assert.IsTrue(test.DeleteSuccess);
        }

        [Test]
        public void NewDeleteExpenditureResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewDeleteExpenditureResponse(true, Guid.Empty); });
        }

        [Test]
        public void NewEditExpenditureResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewEditExpenditureResponse(validDataModel, validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditExpenditureResponse>(test);
            Assert.IsNotNull(test.Expenditure);
        }

        [Test]
        public void NewEditExpenditureResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewEditExpenditureResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewEditExpenditureResponse(validDataModel, Guid.Empty); });
        }

        [Test]
        public void NewGetExpenditureResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewGetExpenditureResponse(validDataModel, validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureResponse>(test);
            Assert.IsNotNull(test.Expenditure);
        }

        [Test]
        public void NewGetExpenditureResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewGetExpenditureResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetExpenditureResponse(validDataModel, Guid.Empty); });
        }

        [Test]
        public void NewGetExpenditureForUserForMonthResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewGetExpenditureForUserForMonthResponse(new List<ExpenditureDataModel>(), validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureForUserForMonthResponse>(test);
            Assert.IsNotNull(test.Data);
        }

        [Test]
        public void NewGetExpenditureForUserForMonthResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetExpenditureForUserForMonthResponse(null, validGuid); });
            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        assembler.NewGetExpenditureForUserForMonthResponse(
                            new List<ExpenditureDataModel>(),
                            Guid.Empty);
                    });
        }

        [Test]
        public void NewGetExpenditureForUserResponse_ValidParams_ReturnsResponse()
        {
            var test = assembler.NewGetExpenditureForUserResponse(
                new List<ExpenditureDataModel> { validDataModel },
                validGuid);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureForUserResponse>(test);
            Assert.IsNotNull(test.Expenditure);
        }

        [Test]
        public void NewGetExpenditureForUserResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetExpenditureForUserResponse(null, validGuid); });

            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        assembler.NewGetExpenditureForUserResponse(
                            new List<ExpenditureDataModel> { validDataModel },
                            Guid.Empty);
                    });
        }

        [Test]
        public void NewExpenditureDataModel_ValidParams_ReturnsDataModel()
        {
            var test = assembler.NewExpenditureDataModel(validProxy);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExpenditureDataModel>(test);
        }

        [Test]
        public void NewExpenditureDataModel_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewExpenditureDataModel(null); });
        }
    }
}