using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Accounting
{
    [Table("Account", Schema = "Accounting")]
    public class Account : BaseEntity
    {
        public long UserId { get; set; }
        [ForeignKey("ParentAccount")]
        public long? ParentAccountId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public double InitialAmount { get; set; }
        public bool OveralTotal { get; set; }
        public bool IsDebit { get; set; }
        public bool IsCredit { get; set; }

        public virtual Account ParentAccount { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Account> ChildAccounts { get; set; }
    }
}