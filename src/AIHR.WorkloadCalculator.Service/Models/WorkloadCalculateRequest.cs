namespace AIHR.WorkloadCalculator.Service
{
    public record WorkloadCalculateRequest
    {
        public WorkloadCalculateRequest()
        {
            
        }

        public WorkloadCalculateRequest(IEnumerable<int> courseIds, DateTime startDate, DateTime endDate)
        {
            CourseIds = courseIds;
            StartDate = startDate;
            EndDate = endDate;
        }
        public IEnumerable<int> CourseIds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
