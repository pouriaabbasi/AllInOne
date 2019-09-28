using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Accounting
{
    [Table("PlanDetail", Schema = "Accounting")]
    public class PlanDetail : BaseEntity
    {
        [Required]
        public long PlanId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public double Amount { get; set; }
        public bool Achieve { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public bool AllowOveral { get; set; }
        
        public virtual Plan Plan { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}