using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Accounting
{
    [Table("CostSheetGroup", Schema = "Accounting")]
    public class CostSheetGroup : BaseEntity
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CostSheet> CostSheets { get; set; }
    }
}