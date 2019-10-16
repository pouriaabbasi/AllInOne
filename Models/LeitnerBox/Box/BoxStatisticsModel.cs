using System.Collections.Generic;

namespace AllInOne.Models.LeitnerBox.Box
{
    public class BoxStatisticsModel
    {
        public string BoxName { get; set; }
        public int AllQuestionCount { get; set; }
        public int ReadyForTestCount { get; set; }
        public int CompeletedQuestionCount { get; set; }
        public int FailCount { get; set; }
        public List<string> Labels { get; set; }
        public List<int> Counts { get; set; }
    }
}