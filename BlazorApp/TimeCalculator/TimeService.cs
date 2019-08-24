using System;
using System.Threading.Tasks;

namespace TimeCalculator
{
    public class TimeService
    {
        public Task<TimeData> GetTime(DateTime targetDate, int gmtOffset)
        {
            var now = DateTime.UtcNow.AddHours(gmtOffset);

            var timeDiff = targetDate - now;

            var bdTimeSpan = BusinessTimeUntil(now, targetDate, new DateTime(2019, 8, 15));

            var daysRemaining =
                Convert.ToDecimal(Math.Round(timeDiff.TotalDays, 2, MidpointRounding.ToPositiveInfinity));

            var hoursRemaining =
                Convert.ToDecimal(Math.Round(timeDiff.TotalHours, 2, MidpointRounding.ToPositiveInfinity));

            var workingDaysRemaining =
                Math.Round(bdTimeSpan.Days + bdTimeSpan.Hours / 8m + bdTimeSpan.Minutes / 60m / 8m, 2,
                    MidpointRounding.ToPositiveInfinity);

            var workingHoursRemaining = bdTimeSpan.Days * 8 + bdTimeSpan.Hours;

            var result = new TimeData
            {
                TargetDate = targetDate,
                TimeSpan = timeDiff,
                BdSpan = bdTimeSpan,
                Days = daysRemaining,
                Hours = hoursRemaining,
                WorkingDays = workingDaysRemaining,
                WorkingHours = workingHoursRemaining
            };

            return Task.FromResult(result);
        }

        private static TimeSpan BusinessTimeUntil(DateTime firstDateTime, DateTime lastDateTime,
            params DateTime[] bankHolidays)
        {
            var firstDay = firstDateTime.Date;
            var lastDay = lastDateTime.Date;
            if (firstDay > lastDay)
                throw new ArgumentException("Incorrect last day " + lastDay);

            var span1Day = new TimeSpan(1, 0, 0, 0);

            var businessSpan = lastDay - firstDay;
            businessSpan += span1Day;

            var fullWeekCount = businessSpan.Days / 7;

            // find out if there are weekends during the time exceedng the full weeks
            if (businessSpan.Days > fullWeekCount * 7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                var firstDayOfWeek = firstDay.DayOfWeek == DayOfWeek.Sunday
                    ? 7
                    : (int) firstDay.DayOfWeek;
                var lastDayOfWeek = lastDay.DayOfWeek == DayOfWeek.Sunday
                    ? 7
                    : (int) lastDay.DayOfWeek;

                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;

                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7) // Both Saturday and Sunday are in the remaining time interval
                        businessSpan -= span1Day * 2;
                    else if (lastDayOfWeek >= 6) // Only Saturday is in the remaining time interval
                        businessSpan -= span1Day;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7) // Only Sunday is in the remaining time interval
                {
                    businessSpan -= span1Day;
                }
            }

            // subtract the weekends during the full weeks in the interval
            businessSpan -= (fullWeekCount + fullWeekCount) * span1Day;

            // subtract the number of bank holidays during the time interval
            foreach (var bankHoliday in bankHolidays)
            {
                var bh = bankHoliday.Date;
                if (firstDay <= bh && bh <= lastDay)
                    businessSpan -= span1Day;
            }

            if (!(firstDateTime.DayOfWeek == DayOfWeek.Saturday || firstDateTime.DayOfWeek == DayOfWeek.Sunday))
            {
                if (firstDateTime.Hour >= 18)
                {
                    businessSpan -= span1Day;
                }
                else if (firstDateTime.Hour >= 10)
                {
                    businessSpan -= span1Day;
                    businessSpan += new TimeSpan(18, 0, 0) -
                                    new TimeSpan(firstDateTime.Hour, firstDateTime.Minute, firstDateTime.Second);
                }
            }

            return businessSpan;
        }
    }
}