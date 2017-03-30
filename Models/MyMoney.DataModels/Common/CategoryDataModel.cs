namespace MyMoney.DataModels.Common
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    ///     The <see cref="CategoryDataModel" /> class represents an entry in the "Category" table.
    /// </summary>
    [Table("Category")]
    public class CategoryDataModel : BaseDataModel
    {
        #region Properties

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
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        #endregion
    }
}