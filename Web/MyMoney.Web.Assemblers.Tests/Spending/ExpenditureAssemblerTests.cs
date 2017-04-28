namespace MyMoney.Web.Assemblers.Tests.Spending
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Assemblers.Spending;
    using Assemblers.Spending.Interfaces;

    using DTO.Request.Spending.Expenditure;
    using DTO.Response.Spending.Expenditure;

    using NUnit.Framework;

    using Proxies.Common;
    using Proxies.Spending;

    using ViewModels.Common;
    using ViewModels.Enum;
    using ViewModels.Spending.Expenditure;

    #endregion

    [Category("Web Assemblers")]
    [TestFixture]
    public class ExpenditureAssemblerTests
    {
        #region Fields

        private IExpenditureAssembler assembler;

        private AddExpenditureResponse validAddExpenditureResponse;

        private Guid validExpenditureId;

        private ExpenditureProxy validExpenditureProxy;

        private ExpenditureViewModel validExpenditureViewModel;

        private EditExpenditureResponse validEditExpenditureResponse;

        private GetExpenditureResponse validGetExpenditureResponse;

        private GetExpenditureForUserResponse validGetExpenditureForUserResponse;

        private Guid validUserId;

        private string validUsername;

        #endregion

        #region Methods

        [Test]
        public void NewAddExpenditureRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewAddExpenditureRequest(null, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewAddExpenditureRequest(validExpenditureViewModel, null); });
        }

        [Test]
        public void NewAddExpenditureRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewAddExpenditureRequest(validExpenditureViewModel, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<AddExpenditureRequest>(test);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreEqual(test.Expenditure.UserId, validExpenditureViewModel.UserId);
            Assert.AreEqual(test.Expenditure.Amount, validExpenditureViewModel.Amount);
            Assert.AreEqual(test.Expenditure.Category.Name, validExpenditureViewModel.Category);
            Assert.AreEqual(test.Expenditure.Id, validExpenditureViewModel.Id);
        }

        [Test]
        public void NewExpenditureViewModel_AddExpenditureResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        AddExpenditureResponse response = null;

                        // ReSharper disable once ExpressionIsAlwaysNull
                        assembler.NewExpenditureViewModel(response);
                    });
        }

        [Test]
        public void NewExpenditureViewModel_AddExpenditureResponse_ValidParams_ReturnsModel()
        {
            var test = assembler.NewExpenditureViewModel(validAddExpenditureResponse);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExpenditureViewModel>(test);
            Assert.AreEqual(test.UserId, validAddExpenditureResponse.Expenditure.UserId);
            Assert.AreEqual(test.Amount, validAddExpenditureResponse.Expenditure.Amount);
            Assert.AreEqual(test.Category, validAddExpenditureResponse.Expenditure.Category.Name);
            Assert.AreEqual(test.Id, validAddExpenditureResponse.Expenditure.Id);
        }

        [Test]
        public void NewExpenditureViewModel_EditExpenditureResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        EditExpenditureResponse response = null;

                        // ReSharper disable once ExpressionIsAlwaysNull
                        assembler.NewExpenditureViewModel(response);
                    });
        }

        [Test]
        public void NewExpenditureViewModel_EditExpenditureResponse_ValidParams_ReturnsModel()
        {
            var test = assembler.NewExpenditureViewModel(validEditExpenditureResponse);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExpenditureViewModel>(test);
            Assert.AreEqual(test.UserId, validEditExpenditureResponse.Expenditure.UserId);
            Assert.AreEqual(test.Amount, validEditExpenditureResponse.Expenditure.Amount);
            Assert.AreEqual(test.Category, validEditExpenditureResponse.Expenditure.Category.Name);
            Assert.AreEqual(test.Id, validEditExpenditureResponse.Expenditure.Id);
        }

        [Test]
        public void NewExpenditureViewModel_GetExpenditureResponse_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate
                    {
                        GetExpenditureResponse response = null;

                        // ReSharper disable once ExpressionIsAlwaysNull
                        assembler.NewExpenditureViewModel(response);
                    });
        }

        [Test]
        public void NewExpenditureViewModel_GetExpenditureResponse_ValidParams_ReturnsModel()
        {
            var test = assembler.NewExpenditureViewModel(validGetExpenditureResponse);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExpenditureViewModel>(test);
            Assert.AreEqual(test.UserId, validGetExpenditureResponse.Expenditure.UserId);
            Assert.AreEqual(test.Amount, validGetExpenditureResponse.Expenditure.Amount);
            Assert.AreEqual(test.Category, validGetExpenditureResponse.Expenditure.Category.Name);
            Assert.AreEqual(test.Id, validGetExpenditureResponse.Expenditure.Id);
        }

        [Test]
        public void NewDeleteExpenditureRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewDeleteExpenditureRequest(Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewDeleteExpenditureRequest(validExpenditureId, string.Empty); });
        }

        [Test]
        public void NewDeleteExpenditureRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewDeleteExpenditureRequest(validExpenditureId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<DeleteExpenditureRequest>(test);
            Assert.AreEqual(test.ExpenditureId, validExpenditureId);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
        }

        [Test]
        public void NewEditExpenditureRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewEditExpenditureRequest(null, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewEditExpenditureRequest(validExpenditureViewModel, string.Empty); });
        }

        [Test]
        public void NewEditExpenditureRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewEditExpenditureRequest(validExpenditureViewModel, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<EditExpenditureRequest>(test);
            Assert.AreEqual(test.Expenditure.Id, validExpenditureViewModel.Id);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
            Assert.AreEqual(test.Expenditure.UserId, validExpenditureViewModel.UserId);
        }

        [Test]
        public void NewGetExpenditureRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetExpenditureRequest(Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetExpenditureRequest(validExpenditureId, string.Empty); });
        }

        [Test]
        public void NewGetExpenditureRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetExpenditureRequest(validExpenditureId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureRequest>(test);
            Assert.AreEqual(test.ExpenditureId, validExpenditureId);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
        }

        [Test]
        public void NewGetExpenditureForUserForMonthRequest_InvalidParams_ThrowsExceptions()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate { assembler.NewGetExpenditureForUserForMonthRequest(-1, validUserId, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetExpenditureForUserForMonthRequest(1, Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetExpenditureForUserForMonthRequest(1, validUserId, string.Empty); });
        }

        [Test]
        public void NewGetExpenditureForUserForMonthRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetExpenditureForUserForMonthRequest(1, validUserId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureForUserForMonthRequest>(test);
            Assert.AreEqual(test.MonthNumber, 1);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreEqual(test.UserId, validUserId);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
        }

        [Test]
        public void NewExportViewModel_Csv_ReturnsViewModel()
        {
            var test = assembler.NewExportViewModel(
                new List<ExpenditureProxy> { validExpenditureProxy },
                ExportType.Csv);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExportViewModel>(test);

            Assert.IsNotNull(test.FileData);
            Assert.IsNotNull(test.FileName);
            Assert.IsNotNull(test.FullFileName);

            Assert.AreEqual(ExportType.Csv, test.ExportType);
        }

        [Test]
        public void NewExportViewModel_Json_ReturnsViewModel()
        {
            var test = assembler.NewExportViewModel(
                new List<ExpenditureProxy> { validExpenditureProxy },
                ExportType.Json);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExportViewModel>(test);

            Assert.IsNotNull(test.FileData);
            Assert.IsNotNull(test.FileName);
            Assert.IsNotNull(test.FullFileName);

            Assert.AreEqual(ExportType.Json, test.ExportType);
        }

        [Test]
        public void NewExportViewModel_Xml_ReturnsViewModel()
        {
            var test = assembler.NewExportViewModel(
                new List<ExpenditureProxy> { validExpenditureProxy },
                ExportType.Xml);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<ExportViewModel>(test);

            Assert.IsNotNull(test.FileData);
            Assert.IsNotNull(test.FileName);
            Assert.IsNotNull(test.FullFileName);

            Assert.AreEqual(ExportType.Xml, test.ExportType);
        }

        [Test]
        public void NewExportViewModel_InvalidParams_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                delegate
                    {
                        assembler.NewExportViewModel(
                            new List<ExpenditureProxy>(),
                            (ExportType)Enum.Parse(typeof(ExportType), "10"));
                    });
        }

        [Test]
        public void NewGetExpenditureForUserRequest_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetExpenditureForUserRequest(Guid.Empty, validUsername); });

            Assert.Throws<ArgumentNullException>(
                delegate { assembler.NewGetExpenditureForUserRequest(validUserId, string.Empty); });
        }

        [Test]
        public void NewGetExpenditureForUserRequest_ValidParams_ReturnsRequest()
        {
            var test = assembler.NewGetExpenditureForUserRequest(validUserId, validUsername);

            Assert.IsNotNull(test);
            Assert.IsInstanceOf<GetExpenditureForUserRequest>(test);
            Assert.AreEqual(test.UserId, validUserId);
            Assert.AreEqual(test.Username, validUsername);
            Assert.AreNotEqual(Guid.Empty, test.RequestReference);
        }

        [Test]
        public void NewTrackExpenditureViewModel_NullParams_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(delegate { assembler.NewTrackExpenditureViewModel(null); });
        }

        [Test]
        public void NewTrackExpenditureViewModel_ValidParams_ReturnsViewModel()
        {
            var test = assembler.NewTrackExpenditureViewModel(validGetExpenditureForUserResponse);

            Assert.IsNotNull(test);
            Assert.IsNotNull(test.AddExpenditure);
            Assert.IsNotNull(test.EditExpenditure);
            Assert.IsInstanceOf<TrackExpenditureViewModel>(test);
            Assert.AreEqual(test.Expenditure.Count, 1);
        }

        [SetUp]
        public void SetUp()
        {
            assembler = new ExpenditureAssembler();
            validUsername = "TEST";
            validExpenditureId = Guid.NewGuid();
            validUserId = Guid.NewGuid();

            validExpenditureProxy = new ExpenditureProxy
                                        {
                                            Amount = 10,
                                            Category =
                                                new CategoryProxy
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        Name = "TEST"
                                                    },
                                            CategoryId = Guid.NewGuid(),
                                            Id = Guid.NewGuid(),
                                            UserId = Guid.NewGuid()
                                        };

            validGetExpenditureResponse =
                new GetExpenditureResponse { Expenditure = validExpenditureProxy, RequestReference = Guid.NewGuid() };

            validExpenditureViewModel =
                new ExpenditureViewModel
                    {
                        Amount = 10,
                        Category = "TEST",
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid()
                    };

            validAddExpenditureResponse =
                new AddExpenditureResponse { Expenditure = validExpenditureProxy, RequestReference = Guid.NewGuid() };

            validEditExpenditureResponse =
                new EditExpenditureResponse { Expenditure = validExpenditureProxy, RequestReference = Guid.NewGuid() };

            validGetExpenditureForUserResponse =
                new GetExpenditureForUserResponse
                    {
                        Expenditure =
                            new List<ExpenditureProxy> { validExpenditureProxy },
                        RequestReference = Guid.NewGuid()
                    };
        }

        [TearDown]
        public void TearDown()
        {
            assembler = null;
            validUsername = null;
            validExpenditureViewModel = null;
            validAddExpenditureResponse = null;
            validGetExpenditureResponse = null;
            validEditExpenditureResponse = null;
            validExpenditureProxy = null;
            validExpenditureId = Guid.Empty;
        }

        #endregion
    }
}