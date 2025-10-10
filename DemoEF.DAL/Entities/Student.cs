﻿namespace DemoEF.DAL.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fee { get; set; }
        public bool Gender { get; set; }
        public int CourseId { get; set; }
        public bool Agree { get; set; }
        public string Profile { get; set; }
        public DateOnly DOB { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Course Course { get; set; }  
        public ICollection<StudentHobby> StudentHobbies { get; set; }
    }
}
