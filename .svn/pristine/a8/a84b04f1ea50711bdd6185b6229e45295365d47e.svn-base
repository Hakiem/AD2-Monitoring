namespace Application.DomainModel
{
    public class PerformanceCounter : IPerformanceCounter
    {

        public PerformanceCounter(){}

        public PerformanceCounter(int _performanceCounterId, string _name, bool _active, string _unit, string _description, string _samplingPeriod)
        {
            PerformanceCounterId = _performanceCounterId;
            Name = _name;
            Active = _active;
            Unit = _unit;
            Description = _description;
            SamplingPeriod = _samplingPeriod;
        }

        public int PerformanceCounterId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public string SamplingPeriod { get; set; }
    }
}
