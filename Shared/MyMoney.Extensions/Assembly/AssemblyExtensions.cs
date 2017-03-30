
#pragma warning disable 169
#pragma warning disable 649

namespace MyMoney.Extensions.Assembly
{
    #region Usings

    using System;
    using System.IO;
    using System.Reflection;

    #endregion

    /// <summary>
    ///     The <see cref="AssemblyExtensions" /> class contains extension methods for the <see cref="Assembly" /> class.
    /// </summary>
    public static class AssemblyExtensions
    {
        #region Methods

        /// <summary>
        ///     Gets the linker time.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="target">The target.</param>
        /// <returns>The time at which the assembly was built.</returns>
        public static DateTime GetLinkerTime(this Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                stream.Read(buffer, 0, 2048);
            }

            var offset = BitConverter.ToInt32(buffer, 60);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + 8);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }

        #endregion
    }
}