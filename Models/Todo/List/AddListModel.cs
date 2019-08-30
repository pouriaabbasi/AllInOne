namespace AllInOne.Models.Todo.List
{
    public class AddListModel
    {
        public string Name { get; set; }
        public long? GroupId { get; set; }
        public long UserId { get; set; }
    }
}