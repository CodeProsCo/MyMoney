namespace MyMoney.DTO.Request.Spending.Expenditure
{
    #region Usings

    using MyMoney.Proxies.Spending;

    #endregion

    /// <summary>
    ///     The <see cref="AddExpenditureRequest" /> class is used when adding a expenditure to the database.
    /// </summary>
    /// <seealso cref="MyMoney.DTO.Request.BaseRequest" />
    public class AddExpenditureRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddExpenditureRequest" /> class.
        /// </summary>
        public AddExpenditureRequest()
            : base("spending/expenditures/add")
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