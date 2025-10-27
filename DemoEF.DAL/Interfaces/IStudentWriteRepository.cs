using DemoEF.DAL.Entities;

namespace Demo.DAL.Interfaces
{
    public interface IStudentWriteRepository
    {
        Task SaveDataAsync(Student student);
        Task UpdateDataAsync(Student student);
        Task DeleteDataAsync(int id);
        Task RemoveImageAsync(int id);
    }
}
