using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.DataModels.Spending
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common;

    [Table("Bill")]
    public class BillDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public double Amount { get; set; }

        public virtual CategoryDataModel Category { get; set; }

        public Guid CategoryId { get; set; }

        public int ReocurringPeriod { get; set; }

        public Guid UserId { get; set; }
    }
}
