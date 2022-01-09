namespace AIHR.WorkloadCalculator.Service
{
    public class WorkloadCalculateHistory
    {
        public int Id { get; set; }
        public List<WorkloadCalculationCourse> Courses { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SuggestedDailyStudyHours { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
