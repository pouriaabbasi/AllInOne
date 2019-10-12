using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.LeitnerBox
{
    [Table("Question", Schema = "LeitnerBox")]
    public class Question : BaseEntity
    {
        public Question()
        {
            CreateDate = DateTime.Now;
        }

        [Required]
        [MaxLength(100)]
        public string Vocabulary { get; set; }
        [Required]
        [MaxLength(100)]
        public string Meaning { get; set; }
        [Required]
        [DefaultValue(1)]
        public byte MainStage { get; set; }
        [Required]
        public byte SubStage { get; set; }
        [Required]
        [DefaultValue(0)]
        public byte FailCount { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public bool IsPending { get; set; }
        public bool IsFinished { get; set; }
        public long BoxId { get; set; }

        public virtual Box Box { get; set; }
        public virtual ICollection<QuestionHistory> QuestionHistory { get; set; }
    }
}