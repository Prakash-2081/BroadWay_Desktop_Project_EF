using Demo.DAL.Models;

namespace DemoEF.DAL.Dto
{
    public class StudentUpdateDto:StudentCreateDto
    {
        public int Id { get; set; }
    }
}
