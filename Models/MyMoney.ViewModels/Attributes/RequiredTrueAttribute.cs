namespace MyMoney.ViewModels.Attributes
{
    #region Usings

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class RequiredTrueAttribute : ValidationAttribute
    {
        #region  Public Methods

        /// <summary>Determines whether the specified value of the object is valid. </summary>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        /// <param name="value">The value of the object to validate. </param>
        public override bool IsValid(object value)
        {
            return bool.Parse(value.ToString());
        }

        #endregion
    }
}