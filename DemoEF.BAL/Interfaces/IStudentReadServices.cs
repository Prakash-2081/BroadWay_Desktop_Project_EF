using Demo.DAL.Dto;
using Demo.DAL.Models;
using DemoEF.DAL.Dto;

namespace Demo.BAL.Interfaces
{
    public interface IStudentReadServices
    {
        Task<StudentDetailDto> GetStudentByIdAsync(int id);
        Task<List<StudentReadDto>> GetAllStudentsAsync();
        Task<List<DropdownDto>> GetAllCoursesAsync();
        Task<List<DropdownDto>> GetAllHobbiesAsync();
    }
}
