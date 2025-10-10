using DemoEF.DAL.Entities;

namespace Demo.DAL.Interfaces
{
    public interface IStudentWriteRepository
    {
        Task SaveDataAsync(Student student);
    }
}
