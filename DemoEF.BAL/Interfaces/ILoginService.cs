using DemoEF.BAL.Dto;

namespace Demo.BAL.Interfaces
{
    public interface ILoginService
    {
        Task<OutputDto> LoginAsync(string username, string password);
    }
}
