namespace MyMoney.DataModels.Authentication
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    ///     The <see cref="UserDataModel" /> class is a mapping of an entry in the "User" table.
    /// </summary>
    [Table("User")]
    public class UserDataModel : BaseDataModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the date of birth.
        /// </summary>
        /// <value>
        ///     The date of birth.
        /// </value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        ///     Gets or sets the email address.
        /// </summary>
        /// <value>
        ///     The email address.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the hash.
        /// </summary>
        /// <value>
        ///     The hash.
        /// </value>
        public byte[] Hash { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the iterations.
        /// </summary>
        /// <value>
        ///     The iterations.
        /// </value>
        public int Iterations { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the salt.
        /// </summary>
        /// <value>
        ///     The salt.
        /// </value>
        public byte[] Salt { get; set; }

        #endregion
    }
}