namespace MyMoney.ViewModels.Attributes
{
    #region Usings

    using System.ComponentModel.DataAnnotations;

    #endregion

    /// <summary>
    ///     The <see cref="RequiredTrueAttribute" /> attribute validates a <see cref="bool" /> and ensures that it is set to
    ///     true.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class RequiredTrueAttribute : ValidationAttribute
    {
        #region Methods

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