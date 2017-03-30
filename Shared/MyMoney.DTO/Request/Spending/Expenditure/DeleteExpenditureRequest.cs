namespace MyMoney.DTO.Request.Spending.Expenditure
{
    #region Usings

    using System;

    using MyMoney.DTO.Request.Interfaces;

    #endregion

    /// <summary>
    ///     The <see cref="DeleteExpenditureRequest" /> class is used for deleting a expenditure from the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    /// <seealso cref="MyMoney.DTO.Request.Interfaces.IDeleteRequest" />
    public class DeleteExpenditureRequest : BaseRequest, IDeleteRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeleteExpenditureRequest" /> class.
        /// </summary>
        public DeleteExpenditureRequest()
            : base("spending/expenditures/delete/{0}/{1}/")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the expenditure identifier.
        /// </summary>
        /// <value>
        ///     The expenditure identifier.
        /// </value>
        public Guid ExpenditureId { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Formats the request URI.
        /// </summary>
        /// <returns>
        ///     The formatted uri.
        /// </returns>
        public string FormatRequestUri()
        {
            return string.Format(GetAction(), ExpenditureId, RequestReference);
        }

        #endregion
    }
}