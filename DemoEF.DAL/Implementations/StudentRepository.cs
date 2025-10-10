using Demo.DAL.Dto;
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
        #endregion Write
    }
}

        