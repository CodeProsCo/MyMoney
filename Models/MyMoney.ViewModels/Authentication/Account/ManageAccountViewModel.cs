namespace MyMoney.ViewModels.Authentication.Account
{
    /// <summary>
    /// The <see cref="ManageAccountViewModel"/> class contains view information for managing accounts.
    /// </summary>
    public class ManageAccountViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the account details.
        /// </summary>
        /// <value>
        /// The account details.
        /// </value>
        public AccountDetailsViewModel AccountDetails { get; set; }

        /// <summary>
        /// Gets or sets the personal details.
        /// </summary>
        /// <value>
        /// The personal details.
        /// </value>
        public PersonalDetailsViewModel PersonalDetails { get; set; }

        #endregion
    }
}