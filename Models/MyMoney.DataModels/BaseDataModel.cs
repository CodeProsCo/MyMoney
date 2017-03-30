namespace MyMoney.DataModels
{
    #region Usings

    using System;

    #endregion

    /// <summary>
    ///     The <see cref="BaseDataModel" /> class is the base class for all data models.
    /// </summary>
    public class BaseDataModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the creation time.
        /// </summary>
        /// <value>
        ///     The creation time.
        /// </value>
        public DateTime CreationTime { get; set; }

        #endregion
    }
}