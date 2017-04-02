namespace MyMoney.ViewModels.Common
{
    #region Usings

    using JetBrains.Annotations;

    using MyMoney.ViewModels.Enum;

    #endregion

    /// <summary>
    /// The <see cref="ExportViewModel"/> class contains view data for an exported object.
    /// </summary>
    public class ExportViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the type of the export.
        /// </summary>
        /// <value>
        /// The type of the export.
        /// </value>
        public ExportType ExportType { private get; set; }

        /// <summary>
        /// Gets or sets the file data.
        /// </summary>
        /// <value>
        /// The file data.
        /// </value>
        public string FileData { [UsedImplicitly] get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { private get; set; }

        /// <summary>
        /// Gets the full name of the file.
        /// </summary>
        /// <value>
        /// The full name of the file.
        /// </value>
        [UsedImplicitly]
        public string FullFileName => $"{FileName}.{ExportType}".ToLower();

        #endregion
    }
}