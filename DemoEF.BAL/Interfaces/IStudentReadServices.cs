using Demo.DAL.Dto;
using DemoEF.BAL.Dto;
using DemoEF.DAL.Dto;

namespace Demo.BAL.Interfaces
{
    public interface IStudentReadServices
    {
        string FilePath { get; }
        Task<OutputDto<DropdownDto>> GetAllCoursesAsync();
        Task<OutputDto<DropdownDto>> GetAllHobbiesAsync();
        Task<OutputDto<StudentReadDto>> GetAllStudentsAsync();
        Task<OutputDto<StudentDetailDto>> GetStudentByIdAsync(int id);
    }
}
