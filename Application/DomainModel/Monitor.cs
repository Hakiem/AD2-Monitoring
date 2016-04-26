using System;

namespace Application.DomainModel
{
    public class Monitor : IMonitor
    {
        public Monitor() { }

        public Monitor(int performanceCounterId, string server, int count, double min, double max, double avg, DateTime @from) 
        {
            PerformanceCounterId = performanceCounterId;
            Server = server;
            Count = count;
            Min = min;
            Max = max;
            Avg = avg;
            From = @from;
        }

        public int PerformanceCounterId { get; set; }
        public string Server { get; set; }
        public int Count { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Avg { get; set; }
        public DateTime From { get; set; }
    }
}
