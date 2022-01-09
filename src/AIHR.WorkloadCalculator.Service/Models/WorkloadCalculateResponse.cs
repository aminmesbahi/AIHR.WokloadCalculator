namespace AIHR.WorkloadCalculator.Service.Models
{
    public record WorkloadCalculateResponse
    {
        public WorkloadCalculateResponse(int suggestedDailyStudyHours)
        {
            SuggestedDailyStudyHours = suggestedDailyStudyHours;
        }
        public int SuggestedDailyStudyHours { get; set; }
    }
}