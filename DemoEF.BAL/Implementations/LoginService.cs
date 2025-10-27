
using Demo.BAL.Interfaces;
using Demo.DAL.Implementations;
using Demo.DAL.Interfaces;
using DemoEF.BAL.Dto;
using DemoEF.BAL.Utilities;

namespace Demo.BAL.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<OutputDto> LoginAsync(string username, string password)
        {
            try
            {
                int count = await _loginRepository.LoginAsync(username, password);
                if (count> 0)
                {
                    return OutputDtoConverter.SetSuccess();
                }
                return OutputDtoConverter.SetFailed("Invalid Login");
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }
    }
}
