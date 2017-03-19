namespace MyMoney.DataModels.Spending
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    #endregion

    /// <summary>
    ///     The <see cref="ExpenditureDataModel" /> class represents an entry in the "Expenditure" table.
    /// </summary>
    /// <seealso cref="MyMoney.DataModels.BaseDataModel" />
    [Table("Expenditure")]
    public class ExpenditureDataModel : BaseDataModel
    {
        #region  Properties

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        public double Amount { get; set; }

        /// <summary>
        ///     Gets or sets the category.
        /// </summary>
        /// <value>
        ///     The category.
        /// </value>
        public CategoryDataModel Category { get; set; }

        /// <summary>
        ///     Gets or sets the category identifier.
        /// </summary>
        /// <value>
        ///     The category identifier.
        /// </value>
        public Guid CategoryId { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the date occurred.
        /// </summary>
        /// <value>
        /// The date occurred.
        /// </value>
        public DateTime DateOccurred { get; set; }

        #endregion
    }
}