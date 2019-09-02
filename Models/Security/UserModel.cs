namespace AllInOne.Models.Security
{
    public class UserModel
    {
        public long Id { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Username { get; internal set; }
        public string Token { get; internal set; }
    }
}