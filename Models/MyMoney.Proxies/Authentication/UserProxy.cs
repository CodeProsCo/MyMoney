namespace MyMoney.Proxies.Authentication
{
    #region Usings

    using System;

    #endregion

    public class UserProxy
    {
        #region  Properties

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public Guid Id { get; set; }

        public string LastName { get; set; }

        #endregion
    }
}