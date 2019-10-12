using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.LeitnerBox.Enums;

namespace AllInOne.Data.Entity.LeitnerBox
{
    [Table("QuestionHistory", Schema = "LeitnerBox")]
    public class QuestionHistory : BaseEntity
    {
        public QuestionHistory()
        {
            Date = DateTime.Now;
        }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public HistoryActionType HistoryActionType { get; set; }
        [Required]
        public byte FromMainStage { get; set; }
        [Required]
        public byte ToMainStage { get; set; }
        [Required]
        public byte FromSubStage { get; set; }
        [Required]
        public byte ToSubStage { get; set; }
        [Required]
        public long QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}