using DemoEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEF.DAL.Configurations
{
    public class HobbyConfiguration : IEntityTypeConfiguration<Hobby>
    {
        public void Configure(EntityTypeBuilder<Hobby> builder)
        {
            builder
               .Property(c => c.Name)
               .HasMaxLength(100)
               .IsRequired();

            builder.HasData(GetHobbies());
        }
        private List<Hobby> GetHobbies()
        {
            var Hobbies = new List<Hobby>()
            {
               new() {Id=1,Name="Entertainment"},
               new() {Id=2,Name="Learning"},
               new() {Id=3,Name="Content Creation"},
               new() {Id=4,Name="Gaming"},
               new() {Id=5,Name="Outdoor games"},
               new() {Id=6,Name="Adventures"}

            };
            return Hobbies;
        }
    }
}
