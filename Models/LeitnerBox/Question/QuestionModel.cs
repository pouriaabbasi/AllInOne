using System;

namespace AllInOne.Models.LeitnerBox.Question
{
    public class QuestionModel
    {
        public long BoxId { get; set; }
        public DateTime CreateDate { get; set; }
        public byte FailCount { get; set; }
        public long Id { get; set; }
        public byte MainStage { get; set; }
        public string Meaning { get; set; }
        public byte SubStage { get; set; }
        public string Vocabulary { get; set; }
        public bool IsPending { get; set; }
        public bool IsFinished { get; set; }
    }
}