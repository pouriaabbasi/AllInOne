using System.Collections.Generic;

namespace AllInOne.Models.LeitnerBox.Question
{
    public class QuestionQueModel
    {
        public byte Stage { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}