namespace MyMoney.DTO.Request.Spending.Expenditure
{
    #region Usings

    using MyMoney.Proxies.Spending;

    #endregion

    /// <summary>
    ///     The <see cref="EditExpenditureRequest" /> class is used for editing a expenditure in the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    public class EditExpenditureRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="EditExpenditureRequest" /> class.
        /// </summary>
        public EditExpenditureRequest()
            : base("spending/expenditures/edit")
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the expenditure.
        /// </summary>
        /// <value>
        ///     The expenditure.
        /// </value>
        public ExpenditureProxy Expenditure { get; set; }

        #endregion
    }
}