using DemoEF.DAL.Entities;

namespace Demo.DAL.Models
{
    public class StudentCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fee { get; set; }
        public bool Gender { get; set; }
        public int CourseId { get; set; }
        public bool Agree { get; set; }
        public string Profile { get; set; }
        public DateOnly DOB { get; set; }
        public List<int> HobbyIds { get; set; }
    }
}
