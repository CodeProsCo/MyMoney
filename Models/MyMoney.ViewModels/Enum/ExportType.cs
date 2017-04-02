namespace MyMoney.ViewModels.Enum
{
    /// <summary>
    /// The <see cref="ExportType"/> enumeration states the type of file we wish to export data in.
    /// </summary>
    public enum ExportType
    {
        /// <summary>
        /// The file will use CSV formatting.
        /// </summary>
        Csv = 0,

        /// <summary>
        /// The file will use XML formatting.
        /// </summary>
        Xml,

        /// <summary>
        /// The file will use JSON formatting.
        /// </summary>
        Json
    }
}