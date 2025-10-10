using DemoEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEF.DAL.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
               .Property(c => c.Name)
               .HasMaxLength(100)
               .IsRequired();
            builder.HasData(GetCourses());
        }
        private List<Course> GetCourses()
        {
            var courses = new List<Course>()
            {
               new() {Id=1,Name="BCA"},
               new() {Id=2,Name="BIM"},
               new() {Id=3,Name="BBS"},
               new() {Id=4,Name="BIT"},
               new() {Id=5,Name="BSC CSIT"}

            };
            return courses;
        }
    }
}
