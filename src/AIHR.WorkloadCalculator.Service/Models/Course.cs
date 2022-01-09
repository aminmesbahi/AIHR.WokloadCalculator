namespace AIHR.WorkloadCalculator.Service.Models
{
    public record Course
    {
        public Course(int id, string name, int duration)
        {
            Id = id;
            Name = name;
            Duration = duration;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
    }
}
