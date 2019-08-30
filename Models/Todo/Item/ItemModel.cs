using System;

namespace AllInOne.Models.Todo.Item
{
    public class ItemModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ListId { get; set; }
        public string ListName { get; set; }
        public long UserId { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}