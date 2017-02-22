namespace MyMoney.ViewModels.Authentication.User
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;

    using Attributes;

    #endregion

    public class RegisterViewModel
    {
        #region  Properties

        [RequiredTrue]
        public bool AcceptTermsAndConditions { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [OverEighteenOnly]
        [DataType(DataType.Date)]
        [UIHint("DateTime")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [UIHint("String")]
        public string FirstName { get; set; }

        [Required]
        [UIHint("String")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [ComplexPassword]
        public string Password { get; set; }

        #endregion
    }
}