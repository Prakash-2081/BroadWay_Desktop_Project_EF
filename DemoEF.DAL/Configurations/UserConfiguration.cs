using DemoEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEF.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
               .Property(x => x.UserName)
               .HasMaxLength(100)
               .IsRequired();

            builder
               .Property(x => x.Password)
               .HasMaxLength(100)
               .IsRequired();

            builder
               .HasData(GetUser());
        }
        public List<User> GetUser()
        {
            var user = new List<User>()
            {
                new()
                {
                    Id=1,
                    UserName = "Prakash",
                    Password = "Prakash@123"
                }
                
            };
            return user;
        }
    }
}
