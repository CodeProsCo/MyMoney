namespace MyMoney.ViewModels.Attributes
{
    #region Usings

    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    #endregion

    public class ComplexPasswordAttribute : ValidationAttribute
    {
        #region  Public Methods

        /// <summary>Determines whether the specified value of the object is valid. </summary>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        /// <param name="value">The value of the object to validate. </param>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var password = value.ToString();

            var valid = Regex.IsMatch(password, @"^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$");

            return valid;
        }

        #endregion
    }
}