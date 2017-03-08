using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Helpers.Security
{
    public class EncryptedPasswordModel
    {
        public byte[] Salt { get; set; }

        public byte[] Hash { get; set; }

        public int Iterations { get; set; }
    }
}
