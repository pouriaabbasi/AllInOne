using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Accounting
{
    [Table("Plane", Schema = "Accounting")]
    public class Plan : BaseEntity
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PlanDetail> PlanDetails { get; set; }
    }
}