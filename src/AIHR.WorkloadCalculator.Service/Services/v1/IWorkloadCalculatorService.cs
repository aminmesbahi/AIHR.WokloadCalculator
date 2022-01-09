namespace AIHR.WorkloadCalculator.Service.Services
{
    public interface IWorkloadCalculatorService
    {
        public Task<IEnumerable<Course>> GetAllCoursesAsync();
        public Task<WorkloadCalculateHistory> WorkloadCalculate(WorkloadCalculateRequest request);
        public Task<IEnumerable<WorkloadCalculateHistory>> GetAllSavedWorkloadCalculationsAsync();
    }
}
