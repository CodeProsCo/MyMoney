namespace MyMoney.DataModels.Spending
{
    #region Usings

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    #endregion

    [Table("Bill")]
    public class BillDataModel
    {
        #region  Properties

        public double Amount { get; set; }

        public virtual CategoryDataModel Category { get; set; }

        public Guid CategoryId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int ReocurringPeriod { get; set; }

        public DateTime StartDate { get; set; }

        public Guid UserId { get; set; }

        #endregion
    }
}