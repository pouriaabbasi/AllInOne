using AllInOne.Models.Security;

namespace AllInOne.Services.Contract.Security
{
    public interface IUserLib
    {
        UserModel Login(LoginModel model);
        bool Register(RegisterModel model);
    }
}