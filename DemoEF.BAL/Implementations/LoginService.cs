
using Demo.BAL.Interfaces;
using Demo.DAL.Implementations;
using Demo.DAL.Interfaces;

namespace Demo.BAL.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
           
            int count=await _loginRepository.LoginAsync(username,password);
            return count > 0;
        }
    }
}
