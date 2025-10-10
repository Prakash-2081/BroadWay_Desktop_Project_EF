using Demo.DAL.Models;

namespace Demo.BAL.Interfaces
{
    public interface IStudentWriteServices
    {
        Task SaveDataAsync(StudentCreateDto request);
    }
}
