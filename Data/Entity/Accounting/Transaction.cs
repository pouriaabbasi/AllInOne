using System;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Accounting
{
    [Table("Transaction", Schema = "Accounting")]
    public class Transaction : BaseEntity
    {
        public long UserId { get; set; }
        public long? PlanDetailId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual PlanDetail PlanDetail { get; set; }
    }
}