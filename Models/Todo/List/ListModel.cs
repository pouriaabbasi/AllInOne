namespace AllInOne.Models.Todo.List
{
    public class ListModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? GroupId { get; set; }
        public string GroupName { get; set; }
    }
}