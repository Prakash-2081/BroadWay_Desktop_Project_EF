using Demo.BAL.Interfaces;
using Demo.DAL.Dto;
using Demo.DAL.Implementations;
using Demo.DAL.Interfaces;
using Demo.DAL.Models;
using DemoEF.BAL.Utilities;
using DemoEF.DAL.Dto;
using DemoEF.DAL.Entities;

namespace Demo.BAL.Implementations
{
    public class StudentServices : IStudentReadServices, IStudentWriteServices
    {
        public const string _fee = "3,00,000";
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;

        public StudentServices(IStudentReadRepository studentReadRepository,IStudentWriteRepository studentWriteRepository)
        {
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
        }


        #region Read
        public async Task<List<StudentReadDto>> GetAllStudentsAsync()
        {
            var students=await _studentReadRepository.GetAllStudentsAsync();
            return students.ConvertToStudentReadDto();
        }

        public async Task<StudentDetailDto> GetStudentByIdAsync(int id)
        {
           var student= await _studentReadRepository.GetStudentByIdAsync(id);
            return student.ConvertToStudentUpdateDto();
        }

        public async Task<List<DropdownDto>> GetAllCoursesAsync()
        {
            var data =await  _studentReadRepository.GetAllCoursesAsync();
            var courses = data.Select(x => new DropdownDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return courses;
        }
       

        public async Task<List<DropdownDto>> GetAllHobbiesAsync()
        {
            var hobbies = await _studentReadRepository.GetAllHobbiesAsync();
            return hobbies
                    .Select(x=>new DropdownDto
                    {
                        Id=x.Id,
                        Name=x.Name
                    }).ToList();
        }

        
        #endregion Read

        #region Save
        public async Task SaveDataAsync(StudentCreateDto request)
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
        }
        #endregion Save
    }
}
