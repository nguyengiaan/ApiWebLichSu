using ApiWebLichSu.Model;
using Microsoft.AspNetCore.Identity;

namespace ApiWebLichSu.Service.Interface
{
    public interface IAccountReponse
    {
        public Task<IdentityResult> SignUpAsync(SignUp mode);
        public Task<string> SignInAsync(SignIn model);
        public Task<IdentityResult> SignUpAsyncAdmin(SignUp mode);
    }
}
