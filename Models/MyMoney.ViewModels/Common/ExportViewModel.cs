using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.ViewModels.Common
{
    using MyMoney.ViewModels.Enum;

    public class ExportViewModel
    {
        public string FileData { get; set; }

        public string FileName { get; set; }

        public ExportType ExportType { get; set; }

        public string FullFileName => $"{FileName}.{ExportType}".ToLower();
    }
}
