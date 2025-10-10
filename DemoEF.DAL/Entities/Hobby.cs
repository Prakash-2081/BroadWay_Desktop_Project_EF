namespace DemoEF.DAL.Entities
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentHobby> StudentHobbies { get; set; }
    }
}
