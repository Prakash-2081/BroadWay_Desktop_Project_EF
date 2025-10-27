using Demo.DAL.Models;
using DemoEF.BAL.Dto;
using DemoEF.DAL.Dto;

namespace Demo.BAL.Interfaces
{
    public interface IStudentWriteServices
    {
        Task<OutputDto> SaveDataAsync(StudentCreateDto request);
        OutputDto<StudentImageResponse> SaveImage(StudentImageRequest request);
        OutputDto RemoveImage(String path);
        Task<OutputDto> RemoveImageAsync(int id,string path);
        Task<OutputDto> UpdateDataAsync(StudentUpdateDto student);
        Task<OutputDto> DeleteDataAsync(int id);
    }
}
