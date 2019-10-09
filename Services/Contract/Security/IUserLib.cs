using System.Threading.Tasks;
using AllInOne.Models.Security;

namespace AllInOne.Services.Contract.Security
{
    public interface IUserLib
    {
        Task<UserModel> LoginAsync(LoginModel model);
        Task<bool> RegisterAsync(RegisterModel model);
    }
}