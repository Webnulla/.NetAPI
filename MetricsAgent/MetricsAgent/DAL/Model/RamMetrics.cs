using System;

namespace MetricsAgent.Model
{
    public class RamMetrics
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
