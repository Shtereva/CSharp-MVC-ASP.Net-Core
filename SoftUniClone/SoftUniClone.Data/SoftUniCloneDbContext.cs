using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SoftUniClone.Data
{
    using Configurations;
    using Models;

    public class SoftUniCloneDbContext : IdentityDbContext<User>
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseInstance> Course { get; set; }
        
        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<ResourceType> ResourceTypes { get; set; }

        public DbSet<StudentCourse> StudentsCourses { get; set; }


        public SoftUniCloneDbContext(DbContextOptions<SoftUniCloneDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CourseConfig());
            builder.ApplyConfiguration(new StudentConfig());
            builder.ApplyConfiguration(new StudentCourseConfig());

            base.OnModelCreating(builder);
        }
    }
}
