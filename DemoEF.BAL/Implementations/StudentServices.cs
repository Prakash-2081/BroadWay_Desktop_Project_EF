using Demo.BAL.Interfaces;
using Demo.DAL.Constants;
using Demo.DAL.Dto;
using Demo.DAL.Interfaces;
using Demo.DAL.Models;
using DemoEF.BAL.Dto;
using DemoEF.BAL.Utilities;
using DemoEF.DAL.Dto;
using DemoEF.DAL.Entities;
using Microsoft.Extensions.Configuration;

namespace Demo.BAL.Implementations
{
    public class StudentServices : IStudentReadServices, IStudentWriteServices
    {
        public const string _fee = "3,00,000";
        public const string _filePathKey = "E:\\BroadWay\\SavedData";
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IConfiguration _configuration;

        public StudentServices(IStudentReadRepository studentReadRepository,IStudentWriteRepository studentWriteRepository,
            IConfiguration configuration)
        {
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _configuration = configuration;
        }


        #region Read
        
        public string FilePath
        {
            get
            {
               return _filePathKey;
            }
        }


        public async Task<OutputDto<DropdownDto>> GetAllCoursesAsync()
        {
            try
            {
                var courseList = await _studentReadRepository.GetAllCoursesAsync();
                var courses = courseList.Select(x => new DropdownDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
               
                return OutputDtoConverter.SetSuccess(courses);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<DropdownDto>(ex.Message);

            }

        }

        public async Task<OutputDto<DropdownDto>> GetAllHobbiesAsync()
        {
            try
            {
                var hobbyList = await _studentReadRepository.GetAllHobbiesAsync();

                var hobbies = hobbyList
                        .Select(x => new DropdownDto
                        {
                            Id = x.Id,
                            Name = x.Name
                        }).ToList();

                return OutputDtoConverter.SetSuccess(hobbies);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<DropdownDto>(ex.Message);
                
            }
        }

        public async Task<OutputDto<StudentReadDto>> GetAllStudentsAsync()
        {
            try
            {
                var students = await _studentReadRepository.GetAllStudentsAsync();
                var result= students.ConvertToStudentReadDto();
                return OutputDtoConverter.SetSuccess(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<StudentReadDto>(ex.Message);
            }
        }

        public async Task<OutputDto<StudentDetailDto>> GetStudentByIdAsync(int id)
        {
            try
            {
                var studentData = await _studentReadRepository.GetStudentByIdAsync(id);
                var student= studentData.ConvertToStudentDetailDto();

                if (student is null)
                {

                    return OutputDtoConverter.SetFailed<StudentDetailDto>($"Student with id ${id} not found");
                }
                return OutputDtoConverter.SetSuccess(student);

            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<StudentDetailDto>(ex.Message);
            }
        }

        #endregion Read

        #region Save
        public async Task<OutputDto> SaveDataAsync(StudentCreateDto request)
        {
            try
            {
                List<StudentHobby> studentHobbies = request
                                                       .HobbyIds
                                                       .Select(x => new StudentHobby
                                                       {
                                                           HobbyId = x
                                                       }).ToList();
                Student student = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Fee = request.Fee,
                    Gender = request.Gender,
                    CourseId = request.CourseId,
                    Agree = request.Agree,
                    Profile = request.Profile,
                    DOB = request.DOB,
                    StudentHobbies = studentHobbies
                };
                await _studentWriteRepository.SaveDataAsync(student);
                return OutputDtoConverter.SetSuccess($"Student Saved successfully");
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }

        public OutputDto<StudentImageResponse> SaveImage(StudentImageRequest request)
        {
            try
            {
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }

                string destination = Path.Combine(FilePath,$"{request.Name}_{Guid.NewGuid()}.jpg");

                File.Copy(request.Source,destination,true);

                StudentImageResponse response = new()
                {
                    FileName = destination
                };
                return OutputDtoConverter.SetSuccess(response);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<StudentImageResponse>(ex.Message);
            }
        }
        public OutputDto RemoveImage(String path)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    File.Delete(path);
                    return OutputDtoConverter.SetSuccess();
                }
                return OutputDtoConverter.SetFailed($"File not found with path {path}");
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<StudentImageResponse>(ex.Message);
            }
        }

        public async Task<OutputDto> RemoveImageAsync(int id,string path)
        {
            try
            {
                if (id > 0 && !String.IsNullOrWhiteSpace(path))
                {
                    await _studentWriteRepository.RemoveImageAsync(id);
                    RemoveImage(path);
                }
                return OutputDtoConverter.SetSuccess($"Image Removed successfully");
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }

        public async Task<OutputDto> UpdateDataAsync(StudentUpdateDto request)
        {
            try
            {
                List<StudentHobby> studentHobbies = ParseStudentHobbies(request);

                Student student = new()
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Fee = request.Fee,
                    Gender = request.Gender,
                    CourseId = request.CourseId,
                    DOB = request.DOB,
                    Agree = request.Agree,
                    Profile = request.Profile,
                    StudentHobbies = studentHobbies

                };
                await _studentWriteRepository.UpdateDataAsync(student);
                return OutputDtoConverter.SetSuccess($"Student Updated successfully");
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }

        private static List<StudentHobby> ParseStudentHobbies(StudentUpdateDto request)
        {
            return request
                                                        .HobbyIds
                                                        .Select(x => new StudentHobby
                                                        {
                                                            HobbyId = x
                                                        })
                                                        .ToList();
        }

        public async Task<OutputDto> DeleteDataAsync(int id)
        {
            try
            {
                await _studentWriteRepository.DeleteDataAsync(id);
                return OutputDtoConverter.SetSuccess($"Student Deleted successfully");
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }
        #endregion Save



    }
}
