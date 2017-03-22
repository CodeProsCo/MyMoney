using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.ViewModels.Authentication.Account
{
    using System.ComponentModel.DataAnnotations;

    using Attributes;

    public class PersonalDetailsViewModel
    {
        [UIHint("String")]
        [Required]
        [Display(Name = "Label_FirstName", ResourceType = typeof(Resources.Authentication))]
        public string FirstName { get; set; }

        [UIHint("String")]
        [Required]
        [Display(Name = "Label_LastName", ResourceType = typeof(Resources.Authentication))]
        public string LastName { get; set; }

        [UIHint("DateTime")]
        [Required]
        [OverEighteenOnly]
        [Display(Name = "Label_DateOfBirth", ResourceType = typeof(Resources.Authentication))]
        public DateTime DateOfBirth { get; set; }
    }
}
