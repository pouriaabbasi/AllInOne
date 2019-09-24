using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Accounting
{
    [Table("CostSheet", Schema = "Accounting")]
    public class CostSheet : BaseEntity
    {
        [Required]
        public long UserId { get; set; }
        public long? CostSheetGroupId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public double InitialBalance { get; set; }
        public bool OveralTotal { get; set; }

        public virtual User User { get; set; }
        public virtual CostSheetGroup CostSheetGroup { get; set; }
    }
}