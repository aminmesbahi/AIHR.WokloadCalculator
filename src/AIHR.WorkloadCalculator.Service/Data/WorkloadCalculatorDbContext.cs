using Microsoft.EntityFrameworkCore;

namespace AIHR.WorkloadCalculator.Service.Data
{
    public class WorkloadCalculatorDbContext : DbContext
    {
        public WorkloadCalculatorDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<WorkloadCalculateHistory> CalculationHistory => Set<WorkloadCalculateHistory>();
        public DbSet<WorkloadCalculationCourse> CalculationHistoryCourses => Set<WorkloadCalculationCourse>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(t => t.Name).HasMaxLength(100);
            modelBuilder.Entity<Course>().HasData(Seed.Courses);
            base.OnModelCreating(modelBuilder);
        }
    }
}