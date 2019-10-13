namespace AllInOne.Models.LeitnerBox.Question
{
    public class AddQuestionModel
    {
        public long BoxId { get; set; }
        public long UserId { get; set; }
        public string Meaning { get; set; }
        public string Vocabulary { get; set; }
    }
}