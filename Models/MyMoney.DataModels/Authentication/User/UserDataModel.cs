﻿namespace MyMoney.DataModels.Authentication.User
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    [Table("User")]
    public class UserDataModel
    {
        #region  Properties

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        [Key]
        public Guid Id { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        #endregion
    }
}