namespace MyMoney.ViewModels.Attributes
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;

    #endregion

    /// <summary>
    ///     The <see cref="OverEighteenOnlyAttribute" /> attribute validates a <see cref="DateTime" /> object to ensure at
    ///     least 18 years have passed since that date.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class OverEighteenOnlyAttribute : ValidationAttribute
    {
        #region Methods

        /// <summary>Determines whether the specified value of the object is valid. </summary>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        /// <param name="value">The value of the object to validate. </param>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            DateTime givenDate;

            var minDate = DateTime.Now.AddYears(-18);
            var parsed = DateTime.TryParse(value.ToString(), out givenDate);

            if (parsed)
            {
                return givenDate < minDate;
            }

            return false;
        }

        #endregion
    }
}