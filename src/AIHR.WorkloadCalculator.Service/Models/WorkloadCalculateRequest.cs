namespace AIHR.WorkloadCalculator.Service
{
    public record WorkloadCalculateRequest
    {
        public IEnumerable<int> CourseIds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
