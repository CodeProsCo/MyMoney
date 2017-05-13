namespace MyMoney.Helpers.Logging
{
    #region Usings

    using System;
    using System.IO;

    using Interfaces;

    using JetBrains.Annotations;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using Wrappers;

    #endregion

    /// <summary>
    ///     The log helper performs write operations to the log file.
    /// </summary>
    /// <seealso cref="MyMoney.Helpers.Logging.Interfaces.ILogHelper" />
    [UsedImplicitly]
    public class LogHelper : ILogHelper
    {
        /// <summary>
        ///     The log file format
        /// </summary>
        private const string LogFileFormat = "{0}.log";

        /// <summary>
        ///     The log location format
        /// </summary>
        private const string LogLocationFormat = "C:/logs/{0}/{1}/{2}/{3}/";

        #region Fields

        /// <summary>
        ///     The locker
        /// </summary>
        private static readonly object Locker = new object();

        #endregion

        #region Methods

        /// <summary>
        ///     Logs the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        public void Log(ResponseErrorWrapper error)
        {
            lock (Locker)
            {
                var file = ObtainLog(error.Username);

                using (var writer = File.AppendText(file))
                {
                    var entry = JsonConvert.SerializeObject(error, Formatting.Indented, new StringEnumConverter());

                    writer.Write(entry);
                }
            }
        }

        /// <summary>
        ///     Obtains the log using the format, if the file does not exist, it is created.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="FileStream" /> for the log.</returns>
        private static string ObtainLog(string username)
        {
            var logDirectory = string.Format(
                LogLocationFormat,
                username,
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day);

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            var logFilePath = logDirectory + string.Format(LogFileFormat, DateTime.Now.Hour);

            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Close();
            }

            return logFilePath;
        }

        #endregion
    }
}