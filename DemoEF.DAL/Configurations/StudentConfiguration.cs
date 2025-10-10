using DemoEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF.DAL.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
    public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
               .Property(x => x.FirstName)
               .HasMaxLength(100)
               .IsRequired();

            builder
               .Property(x => x.LastName)
               .HasMaxLength(100)
               .IsRequired();

            builder
               .Property(x => x.Fee)
               .HasMaxLength(150)
               .IsRequired();
           
            builder
                .ToTable(t => t.HasCheckConstraint("CK_Student_Agree_98400", "[Agree] = 1"));

            builder
                .Property(x => x.Profile)
                .HasMaxLength(300);

            builder
                .Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder
               .HasOne(x => x.Course)
               .WithMany(x => x.students)
               .HasForeignKey(x=>x.CourseId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
