namespace MyMoney.DTO.Request.Authentication
{
    #region Usings

    using System;

    #endregion

    public class RegisterUserRequest : BaseRequest
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterUserRequest" /> class.
        /// </summary>
        public RegisterUserRequest()
            : base("auth/user/register")
        {
        }

        #endregion

        #region  Properties

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        #endregion
    }
}