﻿using System;

namespace MetricsAgent.Model
{
    public class DotNetMetrics
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
