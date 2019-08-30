using System.ComponentModel.DataAnnotations;

namespace AllInOne.Models.Todo.Group
{
    public class AddGroupModel
    {
        public string Name { get; set; }
        public long UserId { get; set; }
    }
}