namespace SoftUniClone.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class CourseConfig : IEntityTypeConfiguration<CourseInstance>
    {
        public void Configure(EntityTypeBuilder<CourseInstance> builder)
        {
            builder
                .HasMany(ci => ci.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);
        }
    }
}
