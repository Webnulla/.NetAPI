using System;

namespace MetricsAgent.Requests
{
    public class MetricsCreateRequest<T>
    {
        public MetricsCreateRequest(TimeSpan from, TimeSpan to)
        {
            From = from;
            To = to;
        }
        public TimeSpan From { get; }
        public TimeSpan To { get; }
    }
}