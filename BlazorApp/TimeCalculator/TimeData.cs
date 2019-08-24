using System;

namespace TimeCalculator
{
    public class TimeData
    {
        public DateTime TargetDate { get; set; }

        public TimeSpan TimeSpan { get; set; }

        public TimeSpan BdSpan { get; set; }

        public decimal Hours { get; set; }

        public decimal Days { get; set; }

        public decimal WorkingDays { get; set; }

        public decimal WorkingHours { get; set; }
    }
}