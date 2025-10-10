
using Demo.DAL.Dto;
using DemoEF.DAL.Dto;
using DemoEF.DAL.Entities;

namespace DemoEF.BAL.Utilities
{
    public static class StudentUtility
    {
        public static List<StudentReadDto> ConvertToStudentReadDto(this List<Student> students)
        {
            var studentList = students.Select(x => new StudentReadDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Fee = x.Fee,
                Gender = x.Gender ? "Male" : "Female",
                Agree=x.Agree? "Yes": "No",
                Profile=x.Profile,
                DOB=x.DOB.FormatDate(),
                CreatedDate=x.DOB.FormatDate(),
                Course=x.Course.Name,
                Hobbies=String.Join(", ",x.StudentHobbies
                .Select(h=>h.Hobby.Name)
                .ToList())

            }).ToList();

            return studentList;
        }
        public static StudentDetailDto ConvertToStudentUpdateDto(this Student studentData)
        {
            var student = new StudentDetailDto
            {
                FirstName = studentData.FirstName,
                LastName = studentData.LastName,
                Fee = studentData.Fee,
                Gender = studentData.Gender,
                Profile = studentData.Profile,
                Agree = studentData.Agree,
                Course = studentData.Course.Name,
                DOB = studentData.DOB,
                HobbyIds = studentData.StudentHobbies.Select(x => x.HobbyId).ToList()
            };


            return student;
        }
    }
}
