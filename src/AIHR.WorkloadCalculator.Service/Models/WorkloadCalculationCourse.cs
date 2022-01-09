namespace AIHR.WorkloadCalculator.Service.Models
{
    public class WorkloadCalculationCourse {
        public WorkloadCalculationCourse(int id, string name, int duration)
        {
            Id = id;
            Name = name;
            Duration = duration;
        }
        public WorkloadCalculationCourse(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }
        public int Id { get; set; }
        public int WorkloadCalculateHistoryId { get; set; }
        public WorkloadCalculateHistory WorkloadCalculateHistory { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
    }
}
