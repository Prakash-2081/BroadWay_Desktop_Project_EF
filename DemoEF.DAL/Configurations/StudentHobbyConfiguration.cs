using DemoEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEF.DAL.Configurations
{
    public class StudentHobbyConfiguration : IEntityTypeConfiguration<StudentHobby>
    {
        public void Configure(EntityTypeBuilder<StudentHobby> builder)
        {
            builder
               .HasKey(x => new{ x.StudentId, x.HobbyId });

            builder
               .HasOne(x => x.Hobby)
               .WithMany(x => x.StudentHobbies)
               .HasForeignKey(x => x.HobbyId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentHobbies)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
