using DemoEF.DAL.Entities;

namespace Demo.DAL.Interfaces
{
    public interface IStudentReadRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<List<Course>> GetAllCoursesAsync();
        Task<List<Hobby>> GetAllHobbiesAsync();
        Task<Student> GetStudentByIdAsync(int id);
    }
}
