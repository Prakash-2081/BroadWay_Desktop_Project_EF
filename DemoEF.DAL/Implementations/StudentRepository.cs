using Demo.DAL.Interfaces;
using DemoEF.DAL.Data;
using DemoEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Implementations
{
    public class StudentRepository:IStudentReadRepository,IStudentWriteRepository
    {
        private readonly ApplicationDbContext _context;
        public const string _fee = "300000";

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #region Read
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students=await _context
                              .Students
                              .Include(x=>x.Course)
                              .Include(x=>x.StudentHobbies)
                              .ThenInclude(x=>x.Hobby)
                              .OrderByDescending(x=>x.CreatedDate)
                              .ToListAsync();

            return students;
        }
       
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var students = await _context
                                  .Students
                                  .Include(x => x.Course)
                                  .Include(x => x.StudentHobbies)
                                  .FirstOrDefaultAsync(x=>x.Id==id);
            return students;
        }



        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var courses = await _context.Courses.OrderBy(x=>x.Name).ToListAsync();
            return courses;
        }
       

        public async Task<List<Hobby>> GetAllHobbiesAsync()
        {
            var hobbies = await _context.Hobbies.OrderBy(x=>x.Name).ToListAsync();
            return hobbies;
        }


        #endregion Read

        #region Write

        
        public async Task SaveDataAsync(Student student)
        {
            await _context
                    .Students
                    .AddAsync(student);

            await _context
                    .SaveChangesAsync();
        }

        public async Task UpdateDataAsync(Student student)
        {
            var existingStudent = await _context
                                            .Students
                                            .Include(x=>x.StudentHobbies)
                                            .FirstOrDefaultAsync(x => x.Id == student.Id);
            if (existingStudent is not null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Fee = student.Fee;
                existingStudent.Gender = student.Gender;
                existingStudent.CourseId = student.CourseId;
                existingStudent.DOB = student.DOB;
                existingStudent.StudentHobbies.Clear();
                existingStudent.StudentHobbies = student.StudentHobbies;
                existingStudent.Agree = student.Agree;
                existingStudent.Profile = student.Profile;
            }
            await _context
                     .SaveChangesAsync();
        }

        public async Task DeleteDataAsync(int id)
        {
            var existingStudent = await _context
                                       .Students
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (existingStudent is not null)
            {
                _context.Students.Remove(existingStudent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveImageAsync(int id)
        {
            var existingStudent = await _context
                                        .Students
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (existingStudent is not null)
            {
                existingStudent.Profile = null;
                await _context.SaveChangesAsync();
            }
        }

        #endregion Write
    }
}

        