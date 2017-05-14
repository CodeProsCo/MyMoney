namespace MyMoney.Web.Assemblers
{
    #region Usings

    using System;

    using Helpers.Export.Interfaces;

    #endregion

    /// <summary>
    /// The <see cref="BaseAssembler"/> class is the parent class for all assemblers in the web application.
    /// </summary>
    public class BaseAssembler
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAssembler"/> class.
        /// </summary>
        /// <param name="exportHelper">The export helper.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Exception thrown if the export helper is null.
        /// </exception>
        protected BaseAssembler(IExportHelper exportHelper)
        {
            if (exportHelper == null)
            {
                throw new ArgumentNullException(nameof(exportHelper));
            }

            ExportHelper = exportHelper;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the export helper.
        /// </summary>
        /// <value>
        /// The export helper.
        /// </value>
        protected IExportHelper ExportHelper { get; }

        #endregion
    }
}