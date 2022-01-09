using AIHR.WorkloadCalculator.Service.Data;
using Microsoft.EntityFrameworkCore;

namespace AIHR.WorkloadCalculator.Service.Services.v1
{
    public class WorkloadCalculatorService : IWorkloadCalculatorService
    {
        private readonly WorkloadCalculatorDbContext _context;
        public WorkloadCalculatorService(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetRequiredService<WorkloadCalculatorDbContext>();
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<IEnumerable<WorkloadCalculateHistory>> GetAllSavedWorkloadCalculationsAsync()
        {
            return await _context.CalculationHistory.Include(ch=>ch.Courses).ToListAsync();
        }

        async Task SaveWorkloadCalculationAsync(WorkloadCalculateHistory historyItem)
        {
            await _context.CalculationHistory.AddAsync(historyItem);
            await _context.SaveChangesAsync();
        }

        public async Task<WorkloadCalculateHistory> WorkloadCalculate(WorkloadCalculateRequest request)
        {
            var qry = await _context.Courses.Where(c => request.CourseIds.Contains(c.Id))
                .Select(c => new WorkloadCalculationCourse(c.Name, c.Duration)).ToListAsync();

            var totalHours = qry.Sum(c=>c.Duration);
            var workingDays = (request.EndDate - request.StartDate).Days;
            var res = new WorkloadCalculateHistory { Courses = qry,StartDate=request.StartDate,EndDate=request.EndDate,RequestTime = DateTime.Now,SuggestedDailyStudyHours = totalHours / workingDays };
            await SaveWorkloadCalculationAsync(res);
            return res;
        }

    }
}
