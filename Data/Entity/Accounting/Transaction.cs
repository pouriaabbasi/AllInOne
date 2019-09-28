using System;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Accounting.Enums;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Accounting
{
    [Table("Transaction", Schema = "Accounting")]
    public class Transaction : BaseEntity
    {
        public long UserId { get; set; }
        public long? PlanDetailId { get; set; }
        [ForeignKey("SourceAccount")]
        public long? SourceAccountId { get; set; }
        [ForeignKey("DestinationAccount")]
        public long? DestinationAccountId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }

        public virtual User User { get; set; }
        public virtual PlanDetail PlanDetail { get; set; }
        public virtual Account SourceAccount { get; set; }
        public virtual Account DestinationAccount { get; set; }
    }
}