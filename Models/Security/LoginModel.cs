using AllInOne.Services.Helpers;

namespace AllInOne.Models.Security
{
    public class LoginModel
    {
        private string _username;
        private string _password;

        public string Username
        {
            get
            {
                return _username.ToLower();
            }
            set
            {
                _username = value;
            }
        }
        public string Password
        {
            get
            {
                return _password.HashPassword(this.Username);
            }
            set
            {
                _password = value;
            }
        }
    }
}