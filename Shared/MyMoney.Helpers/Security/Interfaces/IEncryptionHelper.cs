using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Helpers.Security.Interfaces
{
    public interface IEncryptionHelper
    {
        EncryptedPasswordModel EncryptPassword(string password);

        bool ValidatePassword(string givenPassword, byte[] salt, byte[] hash, int iterations);
    }
}
