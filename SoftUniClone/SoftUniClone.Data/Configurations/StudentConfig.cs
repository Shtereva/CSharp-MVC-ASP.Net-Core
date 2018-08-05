namespace SoftUniClone.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class StudentConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(s => s.EnrolledCourses)
                .WithOne(ci => ci.Student)
                .HasForeignKey(ci => ci.StudentId);
        }
    }
}
