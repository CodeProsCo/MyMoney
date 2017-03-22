using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.ViewModels.Authentication.Account
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Attributes;

    public class AccountDetailsViewModel
    {
        [UIHint("String")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Label_EmailAddress", ResourceType = typeof(Resources.Authentication))]
        public string EmailAddress { get; set; }

        [UIHint("NewPassword")]
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Label_NewPassword", ResourceType = typeof(Resources.Authentication))]
        [ComplexPassword]
        [DisplayName(@"NewPassword")]
        public string NewPassword { get; set; }

        [Display(Name = "Label_ConfirmNewPassword", ResourceType = typeof(Resources.Authentication))]
        [UIHint("Password")]
        [DataType(DataType.Password)]
        [Required]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }

        [UIHint("Password")]
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Label_OldPassword", ResourceType = typeof(Resources.Authentication))]
        public string OldPassword { get; set; }
    }
}
